import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:myapp/model/enum/letter.dart';
import 'package:myapp/model/enum/orien.dart';
import 'package:myapp/model/enum/pagePerSheet.dart';
import 'package:myapp/model/enum/printPagesOptions.dart';
import 'package:myapp/model/enum/sidePrintOption.dart';
import 'package:myapp/model/enum/status.dart';
import 'package:myapp/model/listItem.dart';
import 'package:myapp/model/paymentArguments.dart';
import 'package:myapp/model/printRequest.dart';
import 'package:myapp/model/storageService.dart';
import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/screens/new_print_screen.dart';
import 'package:myapp/screens/payment_screen.dart';
import 'package:provider/provider.dart';

import 'package:myapp/model/enum/collate.dart';

class PrintListScreen extends StatefulWidget {
  static const String rotueName = "printscreen";

  const PrintListScreen({Key? key}) : super(key: key);

  @override
  State<PrintListScreen> createState() => _PrintListScreenState();
}

class _PrintListScreenState extends State<PrintListScreen> {
  PrintListProvider? _printProvider = null;

  List<PrintRequest> data = [];

  String payAmount = (45).toString();

  static List<ListItem> status = [
    ListItem(1, "OnHold"),
    ListItem(2, "InProgress"),
    ListItem(3, "Completed"),
    ListItem(4, "Rejected")
  ];
  ListItem statusValue = status.first;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _printProvider = context.read<PrintListProvider>();
    loadData();
    WidgetsFlutterBinding.ensureInitialized();
    Stripe.publishableKey =
        "pk_test_51N5rVYFxWkxWPkD2lPcJ6nG0JmT0i2tKFEjyOVbfN5tIIuhsC7gPuYl7o79wk80EzwEDGDaOs3P3PCXOMRONXqVL00NvliLcMV";
  }

  Future loadData() async {
    var tmpData = await _printProvider?.get(null);

    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    print("called build $data");
    return Scaffold(
      body: SafeArea(
          child: SingleChildScrollView(
              child: Column(
        children: [
          Container(
            height: 100,
            color: Colors.grey,
            child: Center(
                child: Text(
              "eCopy",
              style: TextStyle(fontSize: 50),
            )),
          ),
          Container(
              margin: EdgeInsets.only(left: 300),
              child: ElevatedButton.icon(
                  onPressed: () {
                    StorageService.token = "";
                    Navigator.popUntil(context, (route) => route.isFirst);
                  },
                  icon: Icon(
                    Icons.logout,
                  ),
                  label: Text('Logout'))),
          SizedBox(height: 20),
          Container(
              height: 50,
              width: 250,
              decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient: LinearGradient(colors: [
                    Color.fromARGB(255, 65, 108, 235),
                    Color.fromARGB(153, 77, 11, 220)
                  ])),
              child: InkWell(
                onTap: () {
                  Navigator.pushNamed(context, NewPrintScreen.routeName);
                },
                child: Center(
                    child: Text("Add print request",
                        style: TextStyle(fontSize: 20))),
              )),
          SizedBox(
            height: 15,
          ),
          Container(
            child: Center(
              child: Text(
                'Request number: ${data.length.toString()}',
                style: TextStyle(fontSize: 18),
              ),
            ),
          ),
          SizedBox(
            height: 15,
          ),
          Container(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  width: 130,
                  child: DropdownButton(
                    style: Theme.of(context).textTheme.titleLarge,
                    value: statusValue,
                    onChanged: (ListItem? value) {
                      setState(() {
                        statusValue = value!;
                      });
                    },
                    items: status
                        .map<DropdownMenuItem<ListItem>>((ListItem value) {
                      return DropdownMenuItem<ListItem>(
                        value: value,
                        child: Text(value.name!),
                      );
                    }).toList(),
                  ),
                ),
                Container(
                    height: 30,
                    width: 90,
                    decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(10),
                        gradient: LinearGradient(colors: [
                          Color.fromARGB(255, 65, 108, 235),
                          Color.fromARGB(153, 77, 11, 220)
                        ])),
                    child: InkWell(
                      onTap: () async {
                        var tmpData = await _printProvider
                            ?.get({'Status': statusValue.name});
                        setState(() {
                          data = tmpData!;
                        });
                      },
                      child: Center(
                          child:
                              Text("Search", style: TextStyle(fontSize: 20))),
                    )),
                Container(
                    height: 30,
                    width: 90,
                    margin: EdgeInsets.only(left: 5),
                    decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(10),
                        gradient: LinearGradient(colors: [
                          Color.fromARGB(255, 65, 108, 235),
                          Color.fromARGB(153, 77, 11, 220)
                        ])),
                    child: InkWell(
                      onTap: () async {
                        var tmpData = await _printProvider?.get();
                        setState(() {
                          data = tmpData!;
                        });
                      },
                      child: Center(
                          child: Text("Reset", style: TextStyle(fontSize: 20))),
                    )),
              ],
            ),
          ),
          SizedBox(
            height: 15,
          ),
          SingleChildScrollView(
            scrollDirection: Axis.horizontal,
            child: SingleChildScrollView(
              child: DataTable(
                columns: [
                  DataColumn(label: Text('Id')),
                  DataColumn(label: Text('Status')),
                  DataColumn(label: Text('Print pages options')),
                  DataColumn(label: Text('Orientation')),
                  DataColumn(label: Text('Letter')),
                  DataColumn(label: Text('Side print options')),
                  DataColumn(label: Text('Collated print options')),
                  DataColumn(label: Text('Page Per Sheet')),
                  DataColumn(label: Text('Price')),
                  DataColumn(label: Text('Payment Service')),
                ],
                rows: data
                    .map<DataRow>((data) => DataRow(cells: [
                          DataCell(Center(
                            child: Text(data.id ?? ""),
                          )),
                          DataCell(Center(
                            child: Text(Status.map[data.status] ?? ""),
                          )),
                          DataCell(Center(
                            child:
                                Text(PrintPagesOptions.map[data.options] ?? ""),
                          )),
                          DataCell(Center(
                            child: Text(Orien.map[data.orientation] ?? ""),
                          )),
                          DataCell(Center(
                              child: Text(Letter.map[data.letter] ?? ""))),
                          DataCell(Center(
                              child:
                                  Text(SidePrintOption.map[data.side] ?? ""))),
                          DataCell(Center(
                              child: Text(Collated.map[data.collate] ?? ""))),
                          DataCell(Center(
                              child:
                                  Text(data.price?.toStringAsFixed(2) ?? ""))),
                          DataCell(
                            Container(
                              margin: EdgeInsets.all(5),
                              decoration: BoxDecoration(
                                  borderRadius: BorderRadius.circular(10),
                                  gradient: LinearGradient(colors: [
                                    Color.fromARGB(255, 65, 108, 235),
                                    Color.fromARGB(153, 77, 11, 220)
                                  ])),
                              child: InkWell(
                                onTap: () => {
                                  Navigator.pushNamed(
                                      context, PaymentScreen.routeName,
                                      arguments: PaymentArguments(
                                          '${data.id}', data.price))
                                },
                                child: Center(
                                    child: Text("Pay now",
                                        style: TextStyle(fontSize: 20))),
                              ),
                            ),
                          ),
                          DataCell(Center(
                              child: Text(PagePerSheet.map[data.pages] ?? ""))),
                        ]))
                    .toList(),
              ),
            ),
          )
        ],
      ))),
    );
  }
}
