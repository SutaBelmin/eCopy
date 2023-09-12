import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:myapp/model/print_options/collatedResponse.dart';
import 'package:myapp/model/print_options/letterResponse.dart';
import 'package:myapp/model/print_options/orientationResponse.dart';
import 'package:myapp/model/print_options/pagePerSheetResponse.dart';
import 'package:myapp/model/print_options/printPageOptionResponse.dart';
import 'package:myapp/model/print_options/sideResponse.dart';
import 'package:myapp/model/request.dart';
import 'package:myapp/model/requestUpd.dart';
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

class RequestDetailsScreen extends StatefulWidget {
  static const String routeName = "reqDetscreen";
  String id;

  RequestDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<RequestDetailsScreen> createState() => _RequestDetailsScreenState();
}

class _RequestDetailsScreenState extends State<RequestDetailsScreen> {
  RequestProvider? _reqProvider = null;

  RequestUpd _updateData = new RequestUpd();

  Request? data = null;

  var numberOfPages;

  var tData = null;
  var tmpReq = null;

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
    tmpReq = await _reqProvider?.getByMyId(this.widget.id);

    tmpLetter = await _letterProvider?.GetActive();
    tmpOrientation = await _orientationProvider?.GetActive();
    tmpPagePerSheet = await _pagePerSheetProvider?.GetActive();
    tmpPrintPageOption = await _printPageOptionProvider?.GetActive();
    tmpSidePrintOption = await _sidePrintOptionProvider?.GetActive();
    tmpCollatedPrintOption = await _collatedPrintOptionProvider?.GetActive();

    setState(() {
      this.data = tmpReq;

      letterData = tmpLetter!;
      orientationData = tmpOrientation!;
      pagePerSheetData = tmpPagePerSheet!;
      printPageOptionData = tmpPrintPageOption!;
      sidePrintOptionData = tmpSidePrintOption!;
      collatedPrintOptionData = tmpCollatedPrintOption!;

      numberOfPages = (data?.price)! * 10;

      if (data?.comment == null ||
          data?.comment == "null" ||
          data?.comment == "") {
        data?.comment = "There is no comment yet";
      }
    });

    _fLetter = tmpLetter?.firstWhere((x) => x.id == data?.letterId);
    _forientation =
        tmpOrientation?.firstWhere((x) => x.id == data?.orientationId);
    _fPagePerSheet =
        tmpPagePerSheet?.firstWhere((x) => x.id == data?.pagePerSheetId);
    _fPrintPageOption =
        tmpPrintPageOption?.firstWhere((x) => x.id == data?.printPageOptionId);
    _fSidePrintOption =
        tmpSidePrintOption?.firstWhere((x) => x.id == data?.sidePrintOptionId);
    _fCollatedPrintOption = tmpCollatedPrintOption
        ?.firstWhere((x) => x.id == data?.collatedPrintOptionId);
  }

  TextEditingController _nmbrPageController = new TextEditingController();

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    if (tmpReq == null) {
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
                        margin: EdgeInsets.only(top: 10),
                        child: Text(
                          "Comment on your print request:",
                          style: TextStyle(fontSize: 18),
                        ),
                      ),
                      Container(
                          padding: EdgeInsets.all(3),
                          color: Color.fromARGB(255, 204, 201, 201),
                          width: 340,
                          height: 80,
                          child: SingleChildScrollView(
                            child: Text(
                              '${data?.comment}',
                              style: TextStyle(fontSize: 16),
                            ),
                          )),
                      SizedBox(
                        height: 10,
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
                                            "Selected print options",
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
                        padding: EdgeInsets.only(left: 35, top: 10),
                        child: Row(
                          children: [
                            Container(
                              margin: EdgeInsets.only(left: 15),
                              child: Text(
                                "Print request price:  ",
                                style: TextStyle(fontSize: 18),
                              ),
                            ),
                            Container(
                              child: IgnorePointer(
                                ignoring: true,
                                child: Container(
                                  color: Color.fromARGB(255, 204, 201, 201),
                                  width: 150,
                                  child: Center(
                                      child: TextFormField(
                                    controller: _nmbrPageController,
                                    decoration: InputDecoration(
                                        border: OutlineInputBorder(),
                                        hintText: 'Price',
                                        labelText: '${data?.price}',
                                        isDense: true,
                                        contentPadding: EdgeInsets.all(10)),
                                    keyboardType: TextInputType.number,
                                    inputFormatters: <TextInputFormatter>[
                                      FilteringTextInputFormatter.digitsOnly
                                    ],
                                  )),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                      Visibility(
                          visible: !(data?.status != 1 && data?.status != 2),
                          child: Container(
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
                                if (data?.status != 1 && data?.status != 2) {
                                  showDialog(
                                      context: context,
                                      builder: (BuildContext context) =>
                                          AlertDialog(
                                            title: Text(
                                                "Update request isn't possible!"),
                                            content: Text(
                                                style: Theme.of(context)
                                                    .textTheme
                                                    .subtitle2,
                                                "You can update request only when Status is New or OnHold"),
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
                                } else {
                                  try {
                                    _updateData.status = 8;
                                    _updateData.letterId = _fLetter?.id;
                                    _updateData.printPageOptionId =
                                        _fPrintPageOption?.id;
                                    _updateData.pagePerSheetId =
                                        _fPagePerSheet?.id;
                                    _updateData.sidePrintOptionId =
                                        _fSidePrintOption?.id;
                                    _updateData.collatedPrintOptionId =
                                        _fCollatedPrintOption?.id;
                                    _updateData.orientationId =
                                        _forientation?.id;

                                    var reqId = int.parse(widget.id);
                                    var updateReq = await _reqProvider
                                        ?.updateRequest(widget.id, _updateData);

                                    if (updateReq != null) {
                                      showDialog(
                                          context: context,
                                          builder: (BuildContext context) =>
                                              AlertDialog(
                                                title: Text(
                                                    "Print request updated successful!"),
                                                content: Text(
                                                    style: Theme.of(context)
                                                        .textTheme
                                                        .subtitle2,
                                                    "Successfully updated print request"),
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
                                "Save updated changes",
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 16,
                                ),
                              )),
                            ),
                          )),
                      SizedBox(height: 20),
                      Visibility(
                        visible: !(data?.status != 1 && data?.status != 2),
                        child: Container(
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
                              if (data?.status != 1 && data?.status != 2) {
                                showDialog(
                                    context: context,
                                    builder: (BuildContext context) =>
                                        AlertDialog(
                                          title: Text(
                                              "Cancel request isn't possible!"),
                                          content: Text(
                                              style: Theme.of(context)
                                                  .textTheme
                                                  .subtitle2,
                                              "You can cancel request only when Status is New or OnHold"),
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
                              } else {
                                showDialog(
                                    context: context,
                                    builder: (BuildContext context) =>
                                        AlertDialog(
                                          title: Text('Confirmation'),
                                          content: Text(
                                              'Are you sure you want to cancel this print request?'),
                                          actions: <Widget>[
                                            TextButton(
                                              child: Text('No'),
                                              onPressed: () {
                                                Navigator.of(context)
                                                    .pop(false);
                                              },
                                            ),
                                            ElevatedButton(
                                              child: Text('Yes'),
                                              onPressed: () async {
                                                await _reqProvider
                                                    ?.cancelRequest(widget.id);
                                                Navigator.pushNamed(context,
                                                    PrintListScreen.rotueName);
                                              },
                                            ),
                                          ],
                                        ));
                              }
                            },
                            child: Center(
                                child: Text(
                              "Cancel request",
                              style: TextStyle(
                                fontWeight: FontWeight.bold,
                                fontSize: 16,
                              ),
                            )),
                          ),
                        ),
                      ),
                    ],
                  ))));
    }
  }
}
