import 'package:data_table_2/data_table_2.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:myapp/model/user.dart';
import 'package:myapp/model/zahtjev.dart';
import 'package:myapp/providers/new_print_provider.dart';
import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/providers/user_provider.dart';
//import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/screens/new_print_screen.dart';
import 'package:provider/provider.dart';

class PrintListScreen extends StatefulWidget {
  static const String rotueName = "printscreen";

  const PrintListScreen({Key? key}) : super(key: key);

  @override
  State<PrintListScreen> createState() => _PrintListScreenState();
}

class _PrintListScreenState extends State<PrintListScreen> {
  PrintListProvider? _printProvider = null;
  //dynamic data = {};
  List<Zahtjev> data = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _printProvider = context.read<PrintListProvider>();
    loadData();
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
              height: 40,
              margin: EdgeInsets.fromLTRB(220, 5, 5, 0),
              //margin: EdgeInsets.fromLTRB(left, top, right, bottom),
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
            height: 30,
          ),
          Container(
            child: Center(
              child: Text(
                'Broj zahtjeva: ${data!.length.toString()}',
                style: TextStyle(fontSize: 18),
              ),
            ),
          ),
          SizedBox(
            height: 30,
          ),
          SingleChildScrollView(
            scrollDirection: Axis.horizontal,
            child: SingleChildScrollView(
              child: DataTable(
                columns: [
                  DataColumn(label: Text('Status')),
                  DataColumn(label: Text('Print pages options')),
                  DataColumn(label: Text('Orientation')),
                  DataColumn(label: Text('Letter')),
                  DataColumn(label: Text('Side print options')),
                  DataColumn(label: Text('Collated print options')),
                ],
                rows: data
                    .map<DataRow>((data) => DataRow(cells: [
                          DataCell(Center(
                            child: Text("${data.status ?? ""}"),
                          )),
                          DataCell(Center(
                            child: Text("${data.options ?? ""}"),
                          )),
                          DataCell(Center(
                            child: Text("${data.orientation ?? ""}"),
                          )),
                          DataCell(Center(child: Text("${data.letter ?? ""}"))),
                          DataCell(Center(child: Text("${data.side ?? ""}"))),
                          DataCell(
                              Center(child: Text("${data.collate ?? ""}"))),
                        ]))
                    .toList(),
              ),
            ),
          )
        ],
      )),
    );
  }
}
