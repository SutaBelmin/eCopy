import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:myapp/model/zahtjev.dart';
import 'package:provider/provider.dart';

import '../providers/print_list_provider.dart';

class PracticeScreen extends StatefulWidget {
  static const String rotueName = "practicescreen";
  const PracticeScreen({Key? key}) : super(key: key);

  @override
  State<PracticeScreen> createState() => _PracticeScreenState();
}

class _PracticeScreenState extends State<PracticeScreen> {
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
          child: SingleChildScrollView(
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
                      DataCell(Center(child: Text("${data.collate ?? ""}"))),
                    ]))
                .toList(),
          ),
        ),
      )),
    );
  }

  /* List<Widget> _buildPrintCardList() {
    if (data.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Container(
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
                          child: Text("${x.status ?? ""}"),
                        )),
                        DataCell(Center(
                          child: Text("${x.options ?? ""}"),
                        )),
                        DataCell(Center(
                          child: Text("${x.orientation ?? ""}"),
                        )),
                        DataCell(Center(child: Text("${x.letter ?? ""}"))),
                        DataCell(Center(child: Text("${x.side ?? ""}"))),
                        DataCell(Center(child: Text("${x.collate ?? ""}"))),
                      ],
                    ),
                  ],
                ))
            //ako je naziv null prikazat ce empty string
            ))
        .cast<Widget>()
        .toList();
    //posto imamo map moramo uraditi cast u widget kako bi flutter razumio da je ovo widget

    return list;
  }*/
}
