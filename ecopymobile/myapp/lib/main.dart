import 'package:flutter/material.dart';
import 'package:myapp/providers/new_print_provider.dart';
import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/screens/new_print_screen.dart';
import 'package:myapp/screens/print_list_screen.dart';
import 'package:provider/provider.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => PrintListProvider()),
        ChangeNotifierProvider(create: (_) => NewPrintProvider())
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        home: HomePage(),
        onGenerateRoute: (settings) {
          if (settings.name == PrintListScreen.rotueName) {
            return MaterialPageRoute(builder: ((context) => PrintListScreen()));
          } else if (settings.name == NewPrintScreen.routeName) {
            return MaterialPageRoute(builder: ((context) => NewPrintScreen()));
          }
        },
      ),
    ));

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text("Flutter Row Example"),
        ),
        body: SingleChildScrollView(
          child: Column(children: [
            Container(
              height: 350,
              decoration: BoxDecoration(
                  image: DecorationImage(
                      image: AssetImage('assets/slika.jpg'), fit: BoxFit.fill)),
            ),
            Padding(
              padding: EdgeInsets.all(40),
              child: Container(
                child: Column(
                  children: [
                    Container(
                      child: Text(
                        "Login",
                        style: TextStyle(fontSize: 30),
                      ),
                    ),
                    SizedBox(
                      height: 20,
                    ),
                    Container(
                      padding: EdgeInsets.all(8),
                      decoration: BoxDecoration(
                          border:
                              Border(bottom: BorderSide(color: Colors.grey))),
                      child: TextField(
                        decoration: InputDecoration(
                            border: InputBorder.none,
                            hintText: "Email or phone:",
                            hintStyle: TextStyle(color: Colors.grey[400])),
                      ),
                    ),
                    Container(
                      padding: EdgeInsets.all(8),
                      child: TextField(
                        decoration: InputDecoration(
                            border: InputBorder.none,
                            hintText: "Password",
                            hintStyle: TextStyle(color: Colors.grey[400])),
                      ),
                    )
                  ],
                ),
              ),
            ),
            Container(
                height: 50,
                margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    gradient: LinearGradient(colors: [
                      Color.fromARGB(143, 146, 146, 148),
                      Color.fromARGB(143, 184, 184, 185)
                    ])),
                child: InkWell(
                  onTap: () {
                    Navigator.pushNamed(context, PrintListScreen.rotueName);
                  },
                  child: Center(child: Text("Login")),
                )),
            SizedBox(height: 30),
            Text("Forgot password?")
          ]),
        ));
  }
}