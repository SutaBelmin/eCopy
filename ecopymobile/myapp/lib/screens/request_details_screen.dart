import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:myapp/model/enum/collate.dart';
import 'package:myapp/model/enum/letter.dart';
import 'package:myapp/model/enum/orien.dart';
import 'package:myapp/model/enum/pagePerSheet.dart';
import 'package:myapp/model/enum/printPagesOptions.dart';
import 'package:myapp/model/enum/sidePrintOption.dart';
import 'package:myapp/model/listItem.dart';
import 'package:myapp/model/printRequest.dart';
import 'package:myapp/model/updateRequest.dart';
import 'package:myapp/providers/print_list_provider.dart';
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
  PrintListProvider? _printProvider = null;

  UpdateRequest _updateData = new UpdateRequest();

  PrintRequest? data = null;
  ListItem? _selectedLetterOption;
  ListItem? _selectedPagePerSheet;
  ListItem? _selectedPrintPagesOptions;
  ListItem? _selectedSidePrintOption;
  ListItem? _selectedCollatedPrintOptions;
  ListItem? _selectedOrientation;
  var numberOfPages;

  var tData = null;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _printProvider = context.read<PrintListProvider>();
    loadData();
  }

  Future loadData() async {
    //var tData = await _printProvider?.getByMyId(this.widget.id);
    tData = await _printProvider?.getByMyId(this.widget.id);

    setState(() {
      this.data = tData;

      _selectedLetterOption = letter.firstWhere(
        (item) => item.name == Letter.map[data?.letter],
        orElse: () => letter.first,
      );

      _selectedPagePerSheet = pagePerSheet.firstWhere(
        (item) => item.name == PagePerSheet.map[data?.pages],
        orElse: () => pagePerSheet.first,
      );

      _selectedPrintPagesOptions = printPagesOptions.firstWhere(
        (item) => item.name == PrintPagesOptions.map[data?.options],
        orElse: () => printPagesOptions.first,
      );

      _selectedSidePrintOption = sidePrintOption.firstWhere(
        (item) => item.name == SidePrintOption.map[data?.side],
        orElse: () => sidePrintOption.first,
      );

      _selectedCollatedPrintOptions = collatedPrintOptions.firstWhere(
        (item) => item.name == Collated.map[data?.collate],
        orElse: () => collatedPrintOptions.first,
      );

      _selectedOrientation = orientation.firstWhere(
        (item) => item.name == Orien.map[data?.orientation],
        orElse: () => orientation.first,
      );

      numberOfPages = (data?.price)! * 10;

      if (data?.comment == null ||
          data?.comment == "null" ||
          data?.comment == "") {
        data?.comment = "There is no comment yet";
      }
    });
  }

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

  final _formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    if (tData == null) {
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
                                                  value: _selectedLetterOption,
                                                  onChanged: (ListItem? value) {
                                                    setState(() {
                                                      _selectedLetterOption =
                                                          value!;
                                                    });
                                                  },
                                                  items: letter.map<
                                                          DropdownMenuItem<
                                                              ListItem>>(
                                                      (ListItem value) {
                                                    return DropdownMenuItem<
                                                        ListItem>(
                                                      value: value,
                                                      child: Text(value.name!),
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
                                                  value: _selectedPagePerSheet,
                                                  onChanged: (ListItem? value) {
                                                    setState(() {
                                                      _selectedPagePerSheet =
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
                                                      child: Text(value.name!),
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
                                                      _selectedPrintPagesOptions,
                                                  onChanged: (ListItem? value) {
                                                    setState(() {
                                                      _selectedPrintPagesOptions =
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
                                                      child: Text(value.name!),
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
                                                  value:
                                                      _selectedSidePrintOption,
                                                  onChanged: (ListItem? value) {
                                                    setState(() {
                                                      _selectedSidePrintOption =
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
                                                      child: Text(value.name!),
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
                                                      _selectedCollatedPrintOptions,
                                                  onChanged: (ListItem? value) {
                                                    setState(() {
                                                      _selectedCollatedPrintOptions =
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
                                                      child: Text(value.name!),
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
                                                  value: _selectedOrientation,
                                                  onChanged: (ListItem? value) {
                                                    setState(() {
                                                      _selectedOrientation =
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
                                                      child: Text(value.name!),
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
                                _updateData.letter =
                                    _selectedLetterOption?.value;
                                _updateData.pages =
                                    _selectedPagePerSheet?.value;
                                _updateData.side =
                                    _selectedSidePrintOption?.value;
                                _updateData.orientation =
                                    _selectedOrientation?.value;
                                _updateData.collate =
                                    _selectedCollatedPrintOptions?.value;
                                _updateData.options =
                                    _selectedPrintPagesOptions?.value;

                                var reqId = int.parse(widget.id);
                                var updateReq = await _printProvider
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
                      ),
                      SizedBox(height: 20),
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
                                              Navigator.of(context).pop(false);
                                            },
                                          ),
                                          ElevatedButton(
                                            child: Text('Yes'),
                                            onPressed: () async {
                                              await _printProvider
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
                    ],
                  ))));
    }
  }
}
