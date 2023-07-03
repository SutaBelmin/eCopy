import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:myapp/.env';
import 'package:myapp/screens/print_list_screen.dart';
import 'package:provider/provider.dart';

import '../providers/print_list_provider.dart';

class PaymentScreen extends StatefulWidget {
  static const String routeName = "paymentscreen";

  final String id;
  final double amount;
  final bool isPaid;

  String? stripe_sk;
  late String stripe_pk;

  PaymentScreen(
      {Key? key, required this.id, required this.amount, required this.isPaid})
      : super(key: key) {
    stripe_pk = const String.fromEnvironment("stripePublishableKey",
        defaultValue: stripePublishableKey);

    stripe_sk = const String.fromEnvironment("stripeSecretKey",
        defaultValue: stripeSecretKey);

    print("secret $stripe_pk");
  }

  @override
  State<PaymentScreen> createState() => _PaymentScreenState();
}

class _PaymentScreenState extends State<PaymentScreen> {
  PrintListProvider? _printProvider = null;
  Map<String, dynamic>? paymentIntent;
  String payAmount = (15).toString();

  String? stripe_sk = null;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _printProvider = context.read<PrintListProvider>();
    loadData();
  }

  Future loadData() async {
    Stripe.publishableKey = widget.stripe_pk;
    Stripe.merchantIdentifier = 'any string works';
    await Stripe.instance.applySettings();

    stripe_sk = widget.stripe_sk;

    print("secret $stripe_sk");
    print("secret ${widget.stripe_pk}");
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Stripe Payment'),
      ),
      body: Center(
        child: TextButton(
          child: const Text('Make Payment'),
          onPressed: () async {
            await makePayment();
          },
        ),
      ),
    );
  }

  Future<void> makePayment() async {
    if (this.widget.isPaid == true) {
      showDialog(
          context: context,
          builder: (BuildContext context) => AlertDialog(
                title: Text("Already paid"),
                content: Text(
                    style: Theme.of(context).textTheme.subtitle2,
                    "Print request already paid"),
                actions: [
                  TextButton(
                      onPressed: () => Navigator.pushNamed(
                          context, PrintListScreen.rotueName),
                      child: Text("Ok"))
                ],
              ));
      return;
    }
    try {
      String price = this.widget.amount.toString();
      paymentIntent = await createPaymentIntent(price, 'BAM');

      await Stripe.instance
          .initPaymentSheet(
              paymentSheetParameters: SetupPaymentSheetParameters(
                  paymentIntentClientSecret: paymentIntent!['client_secret'],
                  style: ThemeMode.dark,
                  merchantDisplayName: 'Name'))
          .then((value) {});

      displayPaymentSheet();
    } catch (e, s) {
      print('exception:$e$s');
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance.presentPaymentSheet().then((value) {
        _printProvider?.pay(this.widget.id).then((value) => {
              showDialog(
                  context: context,
                  builder: (BuildContext context) => AlertDialog(
                        title: Text("Payment successful!"),
                        content: Text(
                            style: Theme.of(context).textTheme.subtitle2,
                            "Successfully added new payment"),
                        actions: [
                          TextButton(
                              onPressed: () => Navigator.pushNamed(
                                  context, PrintListScreen.rotueName),
                              child: Text("Ok"))
                        ],
                      ))
            });

        paymentIntent = null;
      }).onError((error, stackTrace) {
        print('Error is:--->$error $stackTrace');
      });
    } on StripeException catch (e) {
      print('Error is:---> $e');
      showDialog(
          context: context,
          builder: (_) => const AlertDialog(
                content: Text("Cancelled "),
              ));
    } catch (e) {
      print('$e');
    }
  }

  createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': calculateAmount(amount),
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
        Uri.parse('https://api.stripe.com/v1/payment_intents'),
        headers: {
          'Authorization': 'Bearer $stripe_sk',
          'Content-Type': 'application/x-www-form-urlencoded'
        },
        body: body,
      );
      // ignore: avoid_print
      print('Payment Intent Body->>> ${response.body.toString()}');
      return jsonDecode(response.body);
    } catch (err) {
      // ignore: avoid_print
      print('err charging user: ${err.toString()}');
    }
  }

  calculateAmount(String amount) {
    final calculatedAmout = ((double.parse(amount)) * 100).toInt();
    return calculatedAmout.toString();
  }
}
