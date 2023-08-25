import 'package:flutter/material.dart';
import 'package:myapp/model/passRequest.dart';
import 'package:myapp/providers/user_provider.dart';
import 'package:myapp/screens/account_screen.dart';
import 'package:myapp/widgets/top_navigation_bar.dart';
import 'package:provider/provider.dart';

class PassScreen extends StatefulWidget {
  static const String routeName = "passwordscreen";

  const PassScreen({super.key});

  @override
  State<PassScreen> createState() => _PassScreenState();
}

class _PassScreenState extends State<PassScreen> {
  UserProvider? _userProvider = null;

  TextEditingController _oldpasswordController = new TextEditingController();
  TextEditingController _newpasswordController = new TextEditingController();
  TextEditingController _passwordConfController = new TextEditingController();

  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _userProvider = context.read<UserProvider>();
  }

  bool oldPasswordVisible = false;
  bool passwordVisible = false;
  bool passwordConVisible = false;

  @override
  Widget build(BuildContext context) {
    return TopNavigationBar(
        child: SingleChildScrollView(
      child: Form(
          key: _formKey,
          child: Column(
            children: [
              SizedBox(height: 20),
              Container(
                padding: EdgeInsets.only(left: 30, top: 30, right: 30),
                child: TextFormField(
                  obscureText: !oldPasswordVisible,
                  style: Theme.of(context).textTheme.titleLarge,
                  controller: _oldpasswordController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(),
                      icon: Icon(
                        Icons.password,
                        size: 35,
                      ),
                      hintText: 'Enter your old password',
                      labelText: 'Old Password',
                      isDense: true,
                      contentPadding: EdgeInsets.all(10)),
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Please enter some text';
                    }
                    return null;
                  },
                ),
              ),
              Container(
                margin: EdgeInsets.only(left: 280, top: 5),
                child: ElevatedButton(
                  onPressed: () {
                    setState(() {
                      oldPasswordVisible = !oldPasswordVisible;
                    });
                  },
                  child: Text(oldPasswordVisible ? 'Hide' : 'Show'),
                ),
              ),
              Container(
                padding: EdgeInsets.only(left: 30, top: 10, right: 30),
                child: TextFormField(
                  obscureText: !passwordVisible,
                  style: Theme.of(context).textTheme.titleLarge,
                  controller: _newpasswordController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(),
                      icon: Icon(
                        Icons.password,
                        size: 35,
                      ),
                      hintText: 'Enter your new password',
                      labelText: 'New Password',
                      isDense: true,
                      contentPadding: EdgeInsets.all(10)),
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Please enter some text';
                    }
                    if (!isPasswordValid(value)) {
                      return '''Must contain: 1 digit, 
                          \n1 special character from !@#%^&*,
                          \n1 lowercase letter,1 uppercase letter, 
                          \nMin length of 8 characters''';
                    }
                    return null;
                  },
                ),
              ),
              Container(
                margin: EdgeInsets.only(left: 280, top: 5),
                child: ElevatedButton(
                  onPressed: () {
                    setState(() {
                      passwordVisible = !passwordVisible;
                    });
                  },
                  child: Text(passwordVisible ? 'Hide' : 'Show'),
                ),
              ),
              Container(
                padding: EdgeInsets.only(left: 30, top: 10, right: 30),
                child: TextFormField(
                  obscureText: !passwordConVisible,
                  style: Theme.of(context).textTheme.titleLarge,
                  controller: _passwordConfController,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(),
                      icon: Icon(
                        Icons.password,
                        size: 35,
                      ),
                      hintText: 'Enter your password confirm',
                      labelText: 'Password confirm',
                      isDense: true,
                      contentPadding: EdgeInsets.all(10)),
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Please enter some text';
                    } else if (value != _newpasswordController.text) {
                      return 'Password confirm is not equal to Password';
                    }
                    return null;
                  },
                ),
              ),
              Container(
                margin: EdgeInsets.only(left: 280, top: 5),
                child: ElevatedButton(
                  onPressed: () {
                    setState(() {
                      passwordConVisible = !passwordConVisible;
                    });
                  },
                  child: Text(passwordConVisible ? 'Hide' : 'Show'),
                ),
              ),
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
                    onTap: () async {
                      if (_formKey.currentState!.validate()) {
                        try {
                          PassRequest passRequest = new PassRequest();
                          passRequest.oldPass = _oldpasswordController.text;
                          passRequest.newPass = _newpasswordController.text;
                          passRequest.confPass = _passwordConfController.text;

                          var passResponse =
                              await _userProvider?.ChangePass(passRequest);

                          if (passResponse == true) {
                            showDialog(
                                context: context,
                                builder: (BuildContext context) => AlertDialog(
                                      title:
                                          Text("Password changed successfuly!"),
                                      content: Text(
                                          style: Theme.of(context)
                                              .textTheme
                                              .subtitle2,
                                          "Successfully changed password"),
                                      actions: [
                                        TextButton(
                                            onPressed: () =>
                                                Navigator.pushNamed(context,
                                                    AccountScreen.routeName),
                                            child: Text("Ok"))
                                      ],
                                    ));
                          } else {
                            showDialog(
                                context: context,
                                builder: (BuildContext context) => AlertDialog(
                                      title: Text("Incorrect old password!"),
                                      content: Text(
                                          style: Theme.of(context)
                                              .textTheme
                                              .subtitle2,
                                          "Check your old password"),
                                      actions: [
                                        TextButton(
                                            onPressed: () =>
                                                Navigator.of(context)
                                                    .pop(false),
                                            child: Text("Ok"))
                                      ],
                                    ));
                          }
                        } catch (e) {
                          showDialog(
                              context: context,
                              builder: (BuildContext context) => AlertDialog(
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
                  )),
            ],
          )),
    ));
  }

  bool isPasswordValid(String password) {
    final pattern = r'^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$';

    final regExp = RegExp(pattern);
    return regExp.hasMatch(password);
  }
}
