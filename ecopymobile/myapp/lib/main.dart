import 'package:flutter/material.dart';
import 'package:myapp/model/storageService.dart';
import 'package:myapp/providers/authentication_provider.dart';
import 'package:myapp/providers/city_provider.dart';
import 'package:myapp/providers/new_pr_provider.dart';
import 'package:myapp/providers/new_print_provider.dart';
import 'package:myapp/providers/practice_page_provider.dart';
import 'package:myapp/providers/print_list_provider.dart';
import 'package:myapp/providers/user_provider.dart';
import 'package:myapp/screens/new_print_screen.dart';
import 'package:myapp/screens/payment_screen.dart';
import 'package:myapp/screens/print_list_screen.dart';
import 'package:myapp/screens/registration_screen.dart';
import 'package:provider/provider.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

import 'package:jwt_decode/jwt_decode.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => PrintListProvider()),
        ChangeNotifierProvider(create: (_) => NewPrintProvider()),
        ChangeNotifierProvider(create: (_) => NewPrProvider()),
        ChangeNotifierProvider(create: (_) => UserProvider()),
        ChangeNotifierProvider(create: (_) => PracticePageProvider()),
        ChangeNotifierProvider(create: (_) => AuthenticationProvider()),
        ChangeNotifierProvider(create: (_) => CityProvider())
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        home: HomePage(),
        onGenerateRoute: (settings) {
          if (settings.name == PrintListScreen.rotueName) {
            return MaterialPageRoute(builder: ((context) => PrintListScreen()));
          } else if (settings.name == NewPrintScreen.routeName) {
            return MaterialPageRoute(builder: ((context) => NewPrintScreen()));
          } /*else if (settings.name == PaymentScreen.routeName) {
            return MaterialPageRoute(builder: ((context) => PaymentScreen()));
          }*/
          else if (settings.name == RegistrationScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => RegistrationScreen()));
          } else if (settings.name == HomePage.routeName) {
            return MaterialPageRoute(builder: ((context) => HomePage()));
          }

          var uri = Uri.parse(settings.name!);
          if (uri.pathSegments.length == 2 &&
              "${uri.pathSegments.first}" == PaymentScreen.routeName) {
            String amount = uri.pathSegments[1];
            return MaterialPageRoute(
                builder: (context) => PaymentScreen(amount));
          }
        },
      ),
    ));

class HomePage extends StatelessWidget {
  static const String routeName = "mainScreen";
  late UserProvider _userProvider;
  late AuthenticationProvider _authenticationProvider;
  var storage = FlutterSecureStorage();

  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    _userProvider = context.read<UserProvider>();
    _authenticationProvider = context.read<AuthenticationProvider>();

    void _buildLoading(bool isLoading) {
      if (isLoading == true) {
        showDialog(
            context: context,
            builder: (BuildContext build) => AlertDialog(
                  title: Text("Loading ..."),
                  content: CircularProgressIndicator(),
                ));
      } else {
        Navigator.pop(context);
      }
    }

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
                        controller: _usernameController,
                        decoration: InputDecoration(
                            border: InputBorder.none,
                            hintText: "Username",
                            hintStyle: TextStyle(color: Colors.grey[400])),
                      ),
                    ),
                    Container(
                      padding: EdgeInsets.all(8),
                      child: TextField(
                        obscureText: true,
                        enableSuggestions: false,
                        autocorrect: false,
                        controller: _passwordController,
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
                  onTap: () async {
                    try {
                      var result = await _authenticationProvider.insert({
                        "Username": _usernameController.text,
                        "Password": _passwordController.text
                      });
                      Map<String, dynamic> payload =
                          Jwt.parseJwt(result!.Token);
                      if (payload["role"] == 5 || payload["role"] == "User") {
                        StorageService.token = result.Token;
                        Navigator.pushNamed(context, PrintListScreen.rotueName);

                        _usernameController.text = "";
                        _passwordController.text = "";
                      } else {
                        throw Exception("Invalid login");
                      }
                    } catch (e) {
                      displayDialog(context, "An Error Occurred",
                          "No account was found matching that username and password");
                    }
                  },
                  child: Center(
                      child: Text(
                    "Login",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                  )),
                )),
            SizedBox(height: 30),
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
                    Navigator.pushNamed(context, RegistrationScreen.routeName);
                  },
                  child: Center(
                      child: Text("Don't have an account? Register here",
                          style: TextStyle(
                            fontSize: 16,
                          ))),
                )),
          ]),
        ));
  }

  void displayDialog(BuildContext context, String title, String text) =>
      showDialog(
        context: context,
        builder: (context) =>
            AlertDialog(title: Text(title), content: Text(text)),
      );
}
