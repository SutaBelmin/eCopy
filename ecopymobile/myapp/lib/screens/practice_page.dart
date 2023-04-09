import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:myapp/model/city.dart';
import 'package:myapp/model/printRequest.dart';
import 'package:myapp/providers/city_provider.dart';
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

  CityProvider? _cityProvider = null;
  List<City> data = [];
  String? _tmpCity;
  //dynamic data = {};

  static const List<String> list = <String>['One', 'Two', 'Three', 'Four'];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _cityProvider = context.read<CityProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _cityProvider?.get(null);

    setState(() {
      data = tmpData!;
    });
  }

  String selectedValue = "USA";
  String dropdownValue = list.first;

  @override
  Widget build(BuildContext context) {
    print("called build $data");
    return Scaffold(
      body: SafeArea(
          child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: SingleChildScrollView(
            child: Column(
          children: [
            DropdownButton(
                value: selectedValue,
                onChanged: (String? newValue) {
                  setState(() {
                    selectedValue = newValue!;
                  });
                },
                items: dropdownItems),
            DropdownButton(
              value: dropdownValue,
              onChanged: (String? value) {
                // This is called when the user selects an item.
                setState(() {
                  dropdownValue = value!;
                });
              },
              items: list.map<DropdownMenuItem<String>>((String value) {
                return DropdownMenuItem<String>(
                  value: value,
                  child: Text(value),
                );
              }).toList(),
            ),
            /*Container(
              child: Text("${data.last.name ?? ""}"),
            ),*/
            /*Container(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  DropdownButton(
                    hint: Text("Select City"),
                    value: _tmpCity,
                    items: data.map((item) {
                      return DropdownMenuItem(
                        child: Text("${item.name}"),
                        value: item.id,
                      );
                    }).toList(),
                    onChanged: (value) {
                      setState(() {
                        _tmpCity = value.toString();
                      });
                    },
                  ),
                ],
              ),
            )*/
            DropdownButton(
              hint: Text("Select City"),
              value: _tmpCity,
              items: data.map((item) {
                return DropdownMenuItem(
                  child: Text("${item.name}"),
                  value: item.name,
                );
              }).toList(),
              onChanged: (value) {
                setState(() {
                  _tmpCity = value.toString();
                });
              },
            ),
          ],
        )),
      )),
    );
  }

  List<DropdownMenuItem<String>> get dropdownItems {
    List<DropdownMenuItem<String>> menuItems = [
      DropdownMenuItem(child: Text("USA"), value: "USA"),
      DropdownMenuItem(child: Text("Canada"), value: "Canada"),
      DropdownMenuItem(child: Text("Brazil"), value: "Brazil"),
      DropdownMenuItem(child: Text("England"), value: "England"),
    ];
    return menuItems;
  }
}
/*
String selectCity = "";
final citiesSelected = TextEditingController();

List<String> cities = [
  "Sarajevo",
  "Mostar",
  "Tuzla",
  "Čapljina",
  "Travnik",
  "Bihać"
];*/
