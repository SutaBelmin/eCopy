import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:myapp/model/city.dart';
import 'package:myapp/model/printRequest.dart';
import 'package:myapp/providers/city_provider.dart';
import 'package:provider/provider.dart';

import '../providers/print_list_provider.dart';

class PaymentScreen extends StatefulWidget {
  static const String rotueName = "practicescreen";
  const PaymentScreen({Key? key}) : super(key: key);

  @override
  State<PaymentScreen> createState() => _PaymentScreenState();
}

class _PaymentScreenState extends State<PaymentScreen> {
  @override
  void initState() {
    // TODO: implement initState
    super.initState();

    loadData();
  }

  Future loadData() async {}

  @override
  Widget build(BuildContext context) {
    return Scaffold(body: SafeArea(child: Container(child: Text("Hello"))));
  }
}
