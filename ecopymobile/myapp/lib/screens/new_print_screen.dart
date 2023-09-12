import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:myapp/model/print_options/collatedResponse.dart';
import 'package:myapp/model/print_options/letterResponse.dart';
import 'package:myapp/model/print_options/orientationResponse.dart';
import 'package:myapp/model/print_options/pagePerSheetResponse.dart';
import 'package:myapp/model/print_options/printPageOptionResponse.dart';
import 'package:myapp/model/print_options/sideResponse.dart';
import 'package:myapp/model/request.dart';
import 'package:myapp/providers/collatedPrintOptionProvider.dart';
import 'package:myapp/providers/letter_provider.dart';
import 'package:myapp/providers/orientation_provider.dart';
import 'package:myapp/providers/pagePerSheet_provider.dart';
import 'package:myapp/providers/printPageOptionProvider.dart';
import 'package:myapp/providers/request_provider.dart';
import 'package:myapp/providers/sidePrintOptionProvider.dart';
import 'package:myapp/screens/loading_screen.dart';
import 'package:myapp/screens/print_list_screen.dart';
import 'package:myapp/widgets/top_navigation_bar.dart';
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
  RequestProvider? _reqProvider = null;

  LetterProvider? _letterProvider = null;
  List<LetterResponse> letterData = [];
  LetterResponse? _fLetter;

  OrientationProvider? _orientationProvider = null;
  List<OrientationResponse> orientationData = [];
  OrientationResponse? _forientation;

  PagePerSheetProvider? _pagePerSheetProvider = null;
  List<PagePerSheetResponse> pagePerSheetData = [];
  PagePerSheetResponse? _fPagePerSheet;

  PrintPageOptionProvider? _printPageOptionProvider = null;
  List<PrintPageOptionResponse> printPageOptionData = [];
  PrintPageOptionResponse? _fPrintPageOption;

  SidePrintOptionProvider? _sidePrintOptionProvider = null;
  List<SideResponse> sidePrintOptionData = [];
  SideResponse? _fSidePrintOption;

  CollatedPrintOptionProvider? _collatedPrintOptionProvider = null;
  List<CollatedResponse> collatedPrintOptionData = [];
  CollatedResponse? _fCollatedPrintOption;

  var tmpLetter = null;
  var tmpOrientation = null;
  var tmpPagePerSheet = null;
  var tmpPrintPageOption = null;
  var tmpSidePrintOption = null;
  var tmpCollatedPrintOption = null;

  List<Request> data = [];

  double? printPrice = 45;
  String? value = "40";

  bool checkFile = false;

  TextEditingController _nmbrPageController = new TextEditingController();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _reqProvider = context.read<RequestProvider>();

    _letterProvider = context.read<LetterProvider>();
    _orientationProvider = context.read<OrientationProvider>();
    _pagePerSheetProvider = context.read<PagePerSheetProvider>();
    _printPageOptionProvider = context.read<PrintPageOptionProvider>();
    _sidePrintOptionProvider = context.read<SidePrintOptionProvider>();
    _collatedPrintOptionProvider = context.read<CollatedPrintOptionProvider>();

    loadData();
  }

  Future loadData() async {
    tmpLetter = await _letterProvider?.GetActive();
    tmpOrientation = await _orientationProvider?.GetActive();
    tmpPagePerSheet = await _pagePerSheetProvider?.GetActive();
    tmpPrintPageOption = await _printPageOptionProvider?.GetActive();
    tmpSidePrintOption = await _sidePrintOptionProvider?.GetActive();
    tmpCollatedPrintOption = await _collatedPrintOptionProvider?.GetActive();

    setState(() {
      letterData = tmpLetter!;
      orientationData = tmpOrientation!;
      pagePerSheetData = tmpPagePerSheet!;
      printPageOptionData = tmpPrintPageOption!;
      sidePrintOptionData = tmpSidePrintOption!;
      collatedPrintOptionData = tmpCollatedPrintOption!;
    });
    _fLetter = tmpLetter?.first;
    _forientation = tmpOrientation?.first;
    _fPagePerSheet = tmpPagePerSheet?.first;
    _fPrintPageOption = tmpPrintPageOption?.first;
    _fSidePrintOption = tmpSidePrintOption?.first;
    _fCollatedPrintOption = tmpCollatedPrintOption?.first;
  }

  File? pdfFile;

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    if (tmpLetter == null ||
        tmpOrientation == null ||
        tmpPagePerSheet == null ||
        tmpPrintPageOption == null ||
        tmpSidePrintOption == null ||
        tmpCollatedPrintOption == null) {
      loadData();
      return LoadingScreen();
    } else {
      return TopNavigationBar(
          child: SingleChildScrollView(
              child: Form(
                  key: _formKey,
                  child: Column(
                    children: [
                      Container(
                          margin: EdgeInsets.only(top: 15),
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
                                  });
                                }
                              },
                              child: const Text(
                                'Upload file',
                                style: TextStyle(fontSize: 20),
                              ))),
                      if (checkFile && pdfFile == null)
                        Container(
                          margin: EdgeInsets.symmetric(vertical: 5),
                          child: Text(
                            "Please upload a file",
                            style: TextStyle(color: Colors.red, fontSize: 14),
                          ),
                        ),
                      SizedBox(
                        height: 15,
                      ),
                      Container(
                          color: Color.fromARGB(255, 204, 201, 201),
                          height: 350,
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
                                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                                child: DropdownButton(
                                  style: Theme.of(context).textTheme.titleLarge,
                                  hint: Text("Select Letter"),
                                  value: _fLetter,
                                  isExpanded: true,
                                  items: letterData.map(
                                    (item) {
                                      return DropdownMenuItem<LetterResponse>(
                                        child: Text("${item.name}"),
                                        value: item,
                                      );
                                    },
                                  ).toList(),
                                  onChanged: (LetterResponse? value) {
                                    setState(() {
                                      _fLetter = value;
                                    });
                                  },
                                ),
                              ),
                              Container(
                                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                                child: DropdownButton(
                                  style: Theme.of(context).textTheme.titleLarge,
                                  hint: Text("Select Pages"),
                                  value: _fPagePerSheet,
                                  isExpanded: true,
                                  items: pagePerSheetData.map(
                                    (item) {
                                      return DropdownMenuItem<
                                          PagePerSheetResponse>(
                                        child: Text("${item.name}"),
                                        value: item,
                                      );
                                    },
                                  ).toList(),
                                  onChanged: (PagePerSheetResponse? value) {
                                    setState(() {
                                      _fPagePerSheet = value;
                                    });
                                  },
                                ),
                              ),
                              Container(
                                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                                child: DropdownButton(
                                  style: Theme.of(context).textTheme.titleLarge,
                                  hint: Text("Select Page option"),
                                  value: _fPrintPageOption,
                                  isExpanded: true,
                                  items: printPageOptionData.map(
                                    (item) {
                                      return DropdownMenuItem<
                                          PrintPageOptionResponse>(
                                        child: Text("${item.name}"),
                                        value: item,
                                      );
                                    },
                                  ).toList(),
                                  onChanged: (PrintPageOptionResponse? value) {
                                    setState(() {
                                      _fPrintPageOption = value;
                                    });
                                  },
                                ),
                              ),
                              Container(
                                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                                child: DropdownButton(
                                  style: Theme.of(context).textTheme.titleLarge,
                                  hint: Text("Select Side option"),
                                  value: _fSidePrintOption,
                                  isExpanded: true,
                                  items: sidePrintOptionData.map(
                                    (item) {
                                      return DropdownMenuItem<SideResponse>(
                                        child: Text("${item.name}"),
                                        value: item,
                                      );
                                    },
                                  ).toList(),
                                  onChanged: (SideResponse? value) {
                                    setState(() {
                                      _fSidePrintOption = value;
                                    });
                                  },
                                ),
                              ),
                              Container(
                                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                                child: DropdownButton(
                                  style: Theme.of(context).textTheme.titleLarge,
                                  hint: Text("Select Collate option"),
                                  value: _fCollatedPrintOption,
                                  isExpanded: true,
                                  items: collatedPrintOptionData.map(
                                    (item) {
                                      return DropdownMenuItem<CollatedResponse>(
                                        child: Text("${item.name}"),
                                        value: item,
                                      );
                                    },
                                  ).toList(),
                                  onChanged: (CollatedResponse? value) {
                                    setState(() {
                                      _fCollatedPrintOption = value;
                                    });
                                  },
                                ),
                              ),
                              Container(
                                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                                child: DropdownButton(
                                  style: Theme.of(context).textTheme.titleLarge,
                                  hint: Text("Select Orientation"),
                                  value: _forientation,
                                  isExpanded: true,
                                  items: orientationData.map(
                                    (item) {
                                      return DropdownMenuItem<
                                          OrientationResponse>(
                                        child: Text("${item.name}"),
                                        value: item,
                                      );
                                    },
                                  ).toList(),
                                  onChanged: (OrientationResponse? value) {
                                    setState(() {
                                      _forientation = value;
                                    });
                                  },
                                ),
                              ),
                            ],
                          )),
                      Container(
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
                              return 'Please enter some number';
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
                            setState(() {
                              checkFile = true;
                            });
                            if (_formKey.currentState!.validate()) {
                              if (pdfFile == null) {
                                return;
                              }

                              try {
                                Request _printDat = new Request();
                                _printDat.status = 1;
                                _printDat.sidePrintOptionId =
                                    _fSidePrintOption?.id;
                                _printDat.printPageOptionId =
                                    _fPrintPageOption?.id;
                                _printDat.orientationId = _forientation?.id;
                                _printDat.letterId = _fLetter?.id;
                                _printDat.collatedPrintOptionId =
                                    _fCollatedPrintOption?.id;
                                _printDat.pagePerSheetId = _fPagePerSheet?.id;
                                if (double.parse(_nmbrPageController.text) <
                                    10) {
                                  _printDat.price = 1;
                                } else {
                                  _printDat.price =
                                      double.parse(_nmbrPageController.text) /
                                          10;
                                }

                                var newPrintReq = await _reqProvider!
                                    .insertFile(
                                        pdfFile, 'File', _printDat.toJson());

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
                  ))));
    }
  }
}
