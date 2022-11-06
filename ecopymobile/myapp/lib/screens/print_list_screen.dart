import 'package:data_table_2/data_table_2.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/screens/new_print_screen.dart';

class PrintListScreen extends StatefulWidget {
  static const String rotueName = "printscreen";

  const PrintListScreen({Key? key}) : super(key: key);

  @override
  State<PrintListScreen> createState() => _PrintListScreenState();
}

class _PrintListScreenState extends State<PrintListScreen> {
  @override
  Widget build(BuildContext context) {
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
                  child: SingleChildScrollView(
                      scrollDirection: Axis.horizontal,
                      child: DataTable(
                        headingRowColor: MaterialStateProperty.all(
                            Color.fromARGB(255, 215, 213, 213)),
                        columnSpacing: 40,
                        dataRowColor: MaterialStateProperty.all(
                            Color.fromARGB(255, 255, 255, 255)),
                        columns: [
                          DataColumn(label: Text('Status')),
                          DataColumn(label: Text('Print pages options')),
                          DataColumn(label: Text('Orientation')),
                          DataColumn(label: Text('Letter')),
                          DataColumn(label: Text('Side print options')),
                          DataColumn(label: Text('Collated print options')),
                        ],
                        rows: [
                          DataRow(
                            cells: [
                              DataCell(Center(
                                child: Text("Completed"),
                              )),
                              DataCell(Center(
                                child: Text("All"),
                              )),
                              DataCell(Center(
                                child: Text("Portrait"),
                              )),
                              DataCell(Center(child: Text("A4"))),
                              DataCell(Center(child: Text("Print one sided"))),
                              DataCell(Center(child: Text("Collated"))),
                            ],
                          ),
                        ],
                      )))
            ],
          ),
        ),
      ),
    );
  }
}
