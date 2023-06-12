import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:myapp/model/listItem.dart';
import 'package:myapp/model/printRequest.dart';
import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/screens/print_list_screen.dart';
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
  PrintListProvider? _printProvider = null;

  List<PrintRequest> data = [];
  PrintRequest _printData = new PrintRequest();
  double? printPrice = 45;
  String? value = "40";

  TextEditingController _nmbrPageController = new TextEditingController();

  static List<ListItem> sidePrintOption = [
    ListItem(1, "PrintOneSided"),
    ListItem(2, "PrintBothSides")
  ];
  ListItem sidePrintOptionValue = sidePrintOption.first;

  static List<ListItem> printPagesOptions = [
    ListItem(1, "All"),
    ListItem(2, "Even"),
    ListItem(3, "Odd"),
    ListItem(4, "Custom")
  ];
  ListItem printPagesOptionsValue = printPagesOptions.first;

  static List<ListItem> orientation = [
    ListItem(1, "Portrait"),
    ListItem(2, "Landscape")
  ];
  ListItem orientationValue = orientation.first;

  static List<ListItem> letter = [
    ListItem(1, "A1"),
    ListItem(2, "A2"),
    ListItem(3, "A3"),
    ListItem(4, "A4"),
    ListItem(5, "A5"),
    ListItem(6, "A6")
  ];
  ListItem letterValue = letter.first;

  static List<ListItem> collatedPrintOptions = [
    ListItem(1, "Collated"),
    ListItem(2, "Uncollated")
  ];
  ListItem collatedPrintOptionsValue = collatedPrintOptions.first;

  static List<ListItem> pagePerSheet = [
    ListItem(1, "OnePage"),
    ListItem(2, "TwoPages")
  ];
  ListItem pagePerSheetValue = pagePerSheet.first;

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

  File? pdfFile;

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SafeArea(
            child: SingleChildScrollView(
                child: Form(
                    key: _formKey,
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
                                  final result =
                                      await FilePicker.platform.pickFiles(
                                    type: FileType.custom,
                                    allowedExtensions: ['pdf', 'doc', 'docx'],
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
                                                    value: letterValue,
                                                    onChanged:
                                                        (ListItem? value) {
                                                      setState(() {
                                                        letterValue = value!;
                                                      });
                                                    },
                                                    items: letter.map<
                                                            DropdownMenuItem<
                                                                ListItem>>(
                                                        (ListItem value) {
                                                      return DropdownMenuItem<
                                                          ListItem>(
                                                        value: value,
                                                        child:
                                                            Text(value.name!),
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
                                                    onChanged:
                                                        (ListItem? value) {
                                                      setState(() {
                                                        pagePerSheetValue =
                                                            value!;
                                                      });
                                                    },
                                                    items: pagePerSheet.map<
                                                            DropdownMenuItem<
                                                                ListItem>>(
                                                        (ListItem value) {
                                                      return DropdownMenuItem<
                                                          ListItem>(
                                                        value: value,
                                                        child:
                                                            Text(value.name!),
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
                                                    value:
                                                        printPagesOptionsValue,
                                                    onChanged:
                                                        (ListItem? value) {
                                                      setState(() {
                                                        printPagesOptionsValue =
                                                            value!;
                                                      });
                                                    },
                                                    items: printPagesOptions.map<
                                                            DropdownMenuItem<
                                                                ListItem>>(
                                                        (ListItem value) {
                                                      return DropdownMenuItem<
                                                          ListItem>(
                                                        value: value,
                                                        child:
                                                            Text(value.name!),
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
                                                    onChanged:
                                                        (ListItem? value) {
                                                      setState(() {
                                                        sidePrintOptionValue =
                                                            value!;
                                                      });
                                                    },
                                                    items: sidePrintOption.map<
                                                            DropdownMenuItem<
                                                                ListItem>>(
                                                        (ListItem value) {
                                                      return DropdownMenuItem<
                                                          ListItem>(
                                                        value: value,
                                                        child:
                                                            Text(value.name!),
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
                                                    value:
                                                        collatedPrintOptionsValue,
                                                    onChanged:
                                                        (ListItem? value) {
                                                      setState(() {
                                                        collatedPrintOptionsValue =
                                                            value!;
                                                      });
                                                    },
                                                    items: collatedPrintOptions
                                                        .map<
                                                                DropdownMenuItem<
                                                                    ListItem>>(
                                                            (ListItem value) {
                                                      return DropdownMenuItem<
                                                          ListItem>(
                                                        value: value,
                                                        child:
                                                            Text(value.name!),
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
                                                    onChanged:
                                                        (ListItem? value) {
                                                      setState(() {
                                                        orientationValue =
                                                            value!;
                                                      });
                                                    },
                                                    items: orientation.map<
                                                            DropdownMenuItem<
                                                                ListItem>>(
                                                        (ListItem value) {
                                                      return DropdownMenuItem<
                                                          ListItem>(
                                                        value: value,
                                                        child:
                                                            Text(value.name!),
                                                      );
                                                    }).toList(),
                                                  ),
                                                ),
                                              ],
                                            )
                                          ],
                                        ),
                                      ),
                                    ],
                                  ),
                                )
                              ],
                            )),
                        Container(
                          color: Color.fromARGB(255, 204, 201, 201),
                          margin: EdgeInsets.only(top: 15),
                          width: 340,
                          child: Center(
                              child: TextFormField(
                            controller: _nmbrPageController,
                            decoration: InputDecoration(
                                border: OutlineInputBorder(),
                                hintText: 'Number of pages',
                                labelText: 'Enter number of pages',
                                isDense: true,
                                contentPadding: EdgeInsets.all(10)),
                            keyboardType: TextInputType.number,
                            inputFormatters: <TextInputFormatter>[
                              FilteringTextInputFormatter.digitsOnly
                            ],
                            validator: (value) {
                              if (value!.isEmpty) {
                                return 'Please enter some text';
                              }
                              return null;
                            },
                          )),
                        ),
                        Container(
                          height: 40,
                          margin: EdgeInsets.fromLTRB(100, 15, 100, 0),
                          decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(10),
                              gradient: LinearGradient(colors: [
                                Color.fromARGB(255, 65, 108, 235),
                                Color.fromARGB(153, 77, 11, 220)
                              ])),
                          child: InkWell(
                            onTap: () async {
                              if (_formKey.currentState!.validate()) {
                                try {
                                  _printData.status = 1;
                                  _printData.side = sidePrintOptionValue.value;
                                  _printData.options =
                                      printPagesOptionsValue.value;
                                  _printData.orientation =
                                      orientationValue.value;
                                  _printData.letter = letterValue.value;
                                  _printData.collate =
                                      collatedPrintOptionsValue.value;
                                  _printData.pagePerSheet =
                                      pagePerSheetValue.value;
                                  _printData.price =
                                      double.parse(_nmbrPageController.text) *
                                          0.10;

                                  var newPrintReq = await _printProvider!
                                      .insertFile(
                                          pdfFile, 'File', _printData.toJson());
                                  /*var newPrintReq =
                                      await _printProvider!.insert(_printData);*/
                                  if (newPrintReq != null) {
                                    showDialog(
                                        context: context,
                                        builder: (BuildContext context) =>
                                            AlertDialog(
                                              title: Text(
                                                  "Print request successful!"),
                                              content: Text(
                                                  style: Theme.of(context)
                                                      .textTheme
                                                      .subtitle2,
                                                  "Successfully inserted new print request"),
                                              actions: [
                                                TextButton(
                                                    onPressed: () =>
                                                        Navigator.pushNamed(
                                                            context,
                                                            PrintListScreen
                                                                .rotueName),
                                                    child: Text("Ok"))
                                              ],
                                            ));
                                  }
                                } catch (e) {
                                  showDialog(
                                      context: context,
                                      builder: (BuildContext context) =>
                                          AlertDialog(
                                            title: Text("Error"),
                                            content: Text(
                                                style: Theme.of(context)
                                                    .textTheme
                                                    .subtitle2,
                                                e.toString()),
                                            actions: [
                                              TextButton(
                                                  onPressed: () =>
                                                      Navigator.pop(context),
                                                  child: Text("Ok"))
                                            ],
                                          ));
                                }
                              }
                            },
                            child: Center(
                                child: Text(
                              "Save",
                              style: TextStyle(
                                fontWeight: FontWeight.bold,
                                fontSize: 16,
                              ),
                            )),
                          ),
                        ),
                        SizedBox(height: 20),
                      ],
                    )))));
  }
}
