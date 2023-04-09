import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:myapp/model/enum/collate.dart';
import 'package:myapp/model/enum/letter.dart';
import 'package:myapp/model/enum/orien.dart';
import 'package:myapp/model/enum2/proba.dart';
import 'package:myapp/model/printRequest.dart';
import 'package:myapp/providers/new_pr_provider.dart';
import 'package:myapp/providers/practice_page_provider.dart';
import 'package:myapp/screens/practice_page.dart';
import 'package:provider/provider.dart';

import 'dart:io';
import 'package:file_picker/file_picker.dart';

class NewPrintScreen extends StatefulWidget {
  static const String routeName = "newPrintScreen";
  const NewPrintScreen({Key? key}) : super(key: key);

  @override
  State<NewPrintScreen> createState() => _NewPrintScreenState();
}

class _NewPrintScreenState extends State<NewPrintScreen> {
  NewPrProvider? _printProvider = null;
  //dynamic data = {};
  List<PrintRequest> data = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _printProvider = context.read<NewPrProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _printProvider?.get(null);

    setState(() {
      data = tmpData!;
    });
  }

  static const List<String> orientation = ["Portrait", "Landscape"];
  String orientationValue = orientation.first;

  static const List<String> sidePrintOption = [
    "PrintOneSided",
    "PrintBothSides"
  ];
  String sidePrintOptionValue = sidePrintOption.first;

  static const List<String> lett = ["A1", "A2", "A3", "A4", "A5", "A6"];
  String lettValue = lett.first;

  static const List<String> printPagesOptions = [
    "All",
    "Even",
    "Odd",
    "Custom"
  ];
  String printPagesOptionsValue = printPagesOptions.first;

  static const List<String> pagePerSheet = [
    "OnePage",
    "TwoPages",
    "FourPages",
    "SixPages",
    "EightPages",
    "SixteenPages"
  ];
  String pagePerSheetValue = pagePerSheet.first;

  static const List<String> collatedPrintOptions = ["Collated", "Uncollated"];
  String collatedPrintOptionsValue = collatedPrintOptions.first;

  File? pdfFile;
  @override
  Widget build(BuildContext context) {
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
              margin: EdgeInsets.only(top: 10),
              height: 80,
              width: 340,
              child: ElevatedButton(
                  onPressed: () async {
                    final result = await FilePicker.platform.pickFiles(
                      type: FileType.custom,
                      allowedExtensions: ['pdf', 'doc'],
                    );
                    if (result != null) {
                      final path = result.files.single.path!;
                      setState(() {
                        pdfFile = File(path);
                        //pdfFile.readAsBytesSync()
                      });
                    }
                  },
                  child: const Text(
                    'Upload file',
                    style: TextStyle(fontSize: 20),
                  ))),
          SizedBox(
            height: 30,
          ),
          Container(
              color: Color.fromARGB(255, 204, 201, 201),
              height: 250,
              width: 340,
              child: Column(
                children: [
                  Container(
                    padding: EdgeInsets.fromLTRB(50, 10, 50, 0),
                    child: Row(
                      children: [
                        Column(
                          children: [
                            Container(
                                child: Icon(
                              Icons.print,
                              size: 35,
                            ))
                          ],
                        ),
                        Column(
                          children: [
                            Container(
                              child: Center(
                                  child: Text(
                                " Choose print options",
                                style: TextStyle(fontSize: 20),
                              )),
                            )
                          ],
                        )
                      ],
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.only(left: 30),
                    child: Column(
                      children: [
                        SizedBox(height: 10),
                        Container(
                          child: Row(
                            children: [
                              Column(
                                children: [
                                  Container(
                                    width: 130,
                                    child: DropdownButton(
                                      style: Theme.of(context)
                                          .textTheme
                                          .titleLarge,
                                      value: lettValue,
                                      onChanged: (String? value) {
                                        // This is called when the user selects an item.
                                        setState(() {
                                          lettValue = value!;
                                        });
                                      },
                                      items: lett.map<DropdownMenuItem<String>>(
                                          (String value) {
                                        return DropdownMenuItem<String>(
                                          value: value,
                                          child: Text(value),
                                        );
                                      }).toList(),
                                    ),
                                  ),
                                ],
                              ),
                              Column(
                                children: [
                                  Container(
                                    child: DropdownButton(
                                      style: Theme.of(context)
                                          .textTheme
                                          .titleLarge,
                                      value: pagePerSheetValue,
                                      onChanged: (String? value) {
                                        // This is called when the user selects an item.
                                        setState(() {
                                          pagePerSheetValue = value!;
                                        });
                                      },
                                      items: pagePerSheet
                                          .map<DropdownMenuItem<String>>(
                                              (String value) {
                                        return DropdownMenuItem<String>(
                                          value: value,
                                          child: Text(value),
                                        );
                                      }).toList(),
                                    ),
                                  ),
                                ],
                              )
                            ],
                          ),
                        ),
                        SizedBox(height: 5),
                        Container(
                          child: Row(
                            children: [
                              Column(
                                children: [
                                  Container(
                                    width: 130,
                                    child: DropdownButton(
                                      style: Theme.of(context)
                                          .textTheme
                                          .titleLarge,
                                      value: printPagesOptionsValue,
                                      onChanged: (String? value) {
                                        // This is called when the user selects an item.
                                        setState(() {
                                          printPagesOptionsValue = value!;
                                        });
                                      },
                                      items: printPagesOptions
                                          .map<DropdownMenuItem<String>>(
                                              (String value) {
                                        return DropdownMenuItem<String>(
                                          value: value,
                                          child: Text(value),
                                        );
                                      }).toList(),
                                    ),
                                  ),
                                ],
                              ),
                              Column(
                                children: [
                                  Container(
                                    child: DropdownButton(
                                      style: Theme.of(context)
                                          .textTheme
                                          .titleLarge,
                                      value: sidePrintOptionValue,
                                      onChanged: (String? value) {
                                        // This is called when the user selects an item.
                                        setState(() {
                                          sidePrintOptionValue = value!;
                                        });
                                      },
                                      items: sidePrintOption
                                          .map<DropdownMenuItem<String>>(
                                              (String value) {
                                        return DropdownMenuItem<String>(
                                          value: value,
                                          child: Text(value),
                                        );
                                      }).toList(),
                                    ),
                                  ),
                                ],
                              )
                            ],
                          ),
                        ),
                        SizedBox(height: 5),
                        Container(
                          child: Row(
                            children: [
                              Column(
                                children: [
                                  Container(
                                    width: 130,
                                    child: DropdownButton(
                                      style: Theme.of(context)
                                          .textTheme
                                          .titleLarge,
                                      value: collatedPrintOptionsValue,
                                      onChanged: (String? value) {
                                        // This is called when the user selects an item.
                                        setState(() {
                                          collatedPrintOptionsValue = value!;
                                        });
                                      },
                                      items: collatedPrintOptions
                                          .map<DropdownMenuItem<String>>(
                                              (String value) {
                                        return DropdownMenuItem<String>(
                                          value: value,
                                          child: Text(value),
                                        );
                                      }).toList(),
                                    ),
                                  ),
                                ],
                              ),
                              Column(
                                children: [
                                  Container(
                                    child: DropdownButton(
                                      style: Theme.of(context)
                                          .textTheme
                                          .titleLarge,
                                      value: orientationValue,
                                      onChanged: (String? value) {
                                        // This is called when the user selects an item.
                                        setState(() {
                                          orientationValue = value!;
                                        });
                                      },
                                      items: orientation
                                          .map<DropdownMenuItem<String>>(
                                              (String value) {
                                        return DropdownMenuItem<String>(
                                          value: value,
                                          child: Text(value),
                                        );
                                      }).toList(),
                                    ),
                                  ),
                                ],
                              )
                            ],
                          ),
                        )
                      ],
                    ),
                  )
                ],
              )),
          SizedBox(
            height: 10,
          ),
          Container(
            height: 40,
            //width: 100,
            //margin: EdgeInsets.fromLTRB(220, 10, 5, 40),
            margin: EdgeInsets.fromLTRB(100, 0, 100, 0),
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient: LinearGradient(colors: [
                  Color.fromARGB(255, 65, 108, 235),
                  Color.fromARGB(153, 77, 11, 220)
                ])),
            child: Center(child: Text("Save", style: TextStyle(fontSize: 20))),
          ),
          SizedBox(height: 20),
          Container(
            height: 40,
            margin: EdgeInsets.fromLTRB(100, 0, 100, 0),
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient: LinearGradient(colors: [
                  Color.fromARGB(255, 65, 108, 235),
                  Color.fromARGB(153, 77, 11, 220)
                ])),
            child: InkWell(
              onTap: () =>
                  {Navigator.pushNamed(context, PracticeScreen.rotueName)},
              child: Center(
                  child: Text("Page for practice",
                      style: TextStyle(fontSize: 20))),
            ),
          ),
        ],
      ),
    ));
  }

  Widget _buildComboBox() {
    return Container();
  }
}
