import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:myapp/providers/practice_page_provider.dart';
import 'package:myapp/screens/practice_page.dart';
import 'package:provider/provider.dart';

class NewPrintScreen extends StatefulWidget {
  static const String routeName = "newPrintScreen";
  const NewPrintScreen({Key? key}) : super(key: key);

  @override
  State<NewPrintScreen> createState() => _NewPrintScreenState();
}

class _NewPrintScreenState extends State<NewPrintScreen> {
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
            color: Color.fromARGB(255, 204, 201, 201),
            height: 200,
            width: 340,
            child: Center(
                child: Text(
              "Upload file",
              style: TextStyle(fontSize: 20),
            )),
          ),
          SizedBox(
            height: 20,
          ),
          Container(
            color: Color.fromARGB(255, 204, 201, 201),
            height: 350,
            width: 340,
            child: Center(
                child: Text(
              "Choose print options",
              style: TextStyle(fontSize: 20),
            )),
          ),
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
}
