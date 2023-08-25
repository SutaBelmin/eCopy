import 'package:flutter/material.dart';
import 'package:myapp/model/enum/status.dart';
import 'package:myapp/model/listItem.dart';
import 'package:myapp/model/paymentArguments.dart';
import 'package:myapp/model/printRequest.dart';
import 'package:myapp/model/storageService.dart';
import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/screens/loading_screen.dart';
import 'package:myapp/screens/new_print_screen.dart';
import 'package:myapp/screens/payment_screen.dart';
import 'package:myapp/screens/request_details_screen.dart';
import 'package:myapp/widgets/master_widget.dart';
import 'package:provider/provider.dart';

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

  var tmpData = null;

  static List<ListItem> status = [
    ListItem(1, "New"),
    ListItem(2, "OnHold"),
    ListItem(3, "InProgress"),
    ListItem(4, "AwaitingPayment"),
    ListItem(5, "Completed"),
    ListItem(6, "Rejected"),
    ListItem(7, "Canceled"),
    ListItem(8, "Updated")
  ];
  ListItem statusValue = status.first;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _printProvider = context.read<PrintListProvider>();
    loadData();
  }

  Future loadData() async {
    //var tmpData = await _printProvider?.get(null);
    tmpData = await _printProvider?.get(null);

    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    //print("called build $data");
    if (tmpData == null) {
      loadData();
      return LoadingScreen();
    } else {
      return MasterWidget(
          selectedIndex: 0,
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
                  margin: EdgeInsets.only(left: 230),
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
                      width: 190,
                      child: DropdownButton(
                        style: Theme.of(context).textTheme.titleLarge,
                        value: statusValue,
                        onChanged: (ListItem? value) async {
                          setState(() {
                            statusValue = value!;
                          });
                          var tmpData = await _printProvider
                              ?.get({'Status': statusValue.name});
                          setState(() {
                            data = tmpData!;
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
                        width: 70,
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
                              child: Text("Reset",
                                  style: TextStyle(fontSize: 20))),
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
                      DataColumn(label: Text('Payment')),
                      DataColumn(label: Text('Details')),
                    ],
                    rows: data
                        .map<DataRow>((data) => DataRow(cells: [
                              DataCell(Center(
                                child: Text(data.id ?? ""),
                              )),
                              DataCell(Center(
                                child: Text(Status.map[data.status] ?? ""),
                              )),
                              DataCell(
                                Container(
                                  margin: EdgeInsets.all(5),
                                  decoration: BoxDecoration(
                                      borderRadius: BorderRadius.circular(10),
                                      gradient: LinearGradient(colors: [
                                        Color.fromARGB(255, 65, 108, 235),
                                        Color.fromARGB(153, 77, 11, 220)
                                      ])),
                                  child: data.isPaid!
                                      ? TextButton(
                                          onPressed: null,
                                          child: Center(
                                            child: Text("Paid",
                                                style: TextStyle(fontSize: 20)),
                                          ),
                                          style: ButtonStyle(
                                            foregroundColor:
                                                MaterialStateProperty.all(
                                                    Colors.grey),
                                            overlayColor:
                                                MaterialStateProperty.all(
                                                    Colors.transparent),
                                          ),
                                        )
                                      : InkWell(
                                          onTap: () {
                                            if (data.status == 4) {
                                              Navigator.pushNamed(context,
                                                  PaymentScreen.routeName,
                                                  arguments: PaymentArguments(
                                                      '${data.id}',
                                                      data.price,
                                                      data.isPaid));
                                            } else {
                                              showDialog(
                                                  context: context,
                                                  builder: (BuildContext
                                                          context) =>
                                                      AlertDialog(
                                                        title: Text(
                                                            "Waiting for confirmation from Employee"),
                                                        content: Text(
                                                            style: Theme.of(
                                                                    context)
                                                                .textTheme
                                                                .subtitle2,
                                                            "Print request can be paid only when Status is AwaitingPayment"),
                                                        actions: [
                                                          TextButton(
                                                              child: Text("Ok"),
                                                              onPressed: () {
                                                                Navigator.of(
                                                                        context)
                                                                    .pop(false);
                                                              })
                                                        ],
                                                      ));
                                            }
                                          },
                                          child: Center(
                                            child: Text("Pay",
                                                style: TextStyle(fontSize: 20)),
                                          ),
                                        ),
                                ),
                              ),
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
                                      Navigator.pushNamed(context,
                                          "${RequestDetailsScreen.routeName}/${data.id}")
                                    },
                                    child: Center(
                                        child: Text("Details",
                                            style: TextStyle(fontSize: 20))),
                                  ),
                                ),
                              ),
                            ]))
                        .toList(),
                  ),
                ),
              )
            ],
          )));
    }
  }
}
