import 'package:flutter/material.dart';
import 'package:myapp/model/city.dart';
import 'package:myapp/model/listItem.dart';
import 'package:myapp/model/registrationModel/applicationUserRequest.dart';
import 'package:myapp/model/registrationModel/clientRequest.dart';
import 'package:myapp/model/registrationModel/personRequest.dart';
import 'package:myapp/providers/city_provider.dart';
import 'package:myapp/providers/user_provider.dart';
import 'package:provider/provider.dart';

class RegistrationScreen extends StatefulWidget {
  static const String routeName = "registrationscreen";
  const RegistrationScreen({super.key});

  @override
  State<RegistrationScreen> createState() => _RegistrationScreenState();
}

class _RegistrationScreenState extends State<RegistrationScreen> {
  UserProvider? _userProvider = null;
  ClientRequest _clientData = new ClientRequest();
  CityProvider? _cityProvider = null;
  List<City> data = [];
  City? _tmpCity;

  TextEditingController _firstNameController = new TextEditingController();
  TextEditingController _lastNameController = new TextEditingController();
  TextEditingController _middleNameController = new TextEditingController();
  TextEditingController _addressController = new TextEditingController();
  TextEditingController _birthDateController = new TextEditingController();
  TextEditingController _emailController = new TextEditingController();
  TextEditingController _usernameController = new TextEditingController();
  TextEditingController _phoneNumberController = new TextEditingController();
  TextEditingController _passwordController = new TextEditingController();
  TextEditingController _passwordConfirmController =
      new TextEditingController();

  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _cityProvider = context.read<CityProvider>();
    _userProvider = context.read<UserProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _cityProvider?.get(null);

    setState(() {
      data = tmpData!;
    });
    _tmpCity = tmpData?.first;
  }

  int role = 5;

  static List<ListItem> gender = [ListItem(0, "Male"), ListItem(1, "Female")];
  ListItem genderValue = gender.first;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SafeArea(
            child: SingleChildScrollView(child: _buildRegisterForm())));
  }

  Widget _buildRegisterForm() {
    return Form(
      key: _formKey,
      child: Container(
        child: Column(children: [
          Container(
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _firstNameController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.person,
                    size: 35,
                  ),
                  hintText: 'Enter your first name',
                  labelText: 'First name',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _lastNameController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.person,
                    size: 35,
                  ),
                  hintText: 'Enter your last name',
                  labelText: 'Last name',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _middleNameController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.person,
                    size: 35,
                  ),
                  hintText: 'Enter your middle name',
                  labelText: 'Middle name',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: Row(
              children: [
                Column(
                  children: [
                    Container(
                      child: Icon(
                        Icons.male_outlined,
                        size: 35,
                        color: Colors.grey,
                      ),
                    )
                  ],
                ),
                Column(
                  children: [
                    Container(
                      child:
                          Text("    Gender  ", style: TextStyle(fontSize: 20)),
                    )
                  ],
                ),
                Column(
                  children: [
                    Container(
                      child: DropdownButton(
                        style: Theme.of(context).textTheme.titleLarge,
                        value: genderValue,
                        onChanged: (ListItem? value) {
                          setState(() {
                            genderValue = value!;
                          });
                        },
                        items: gender
                            .map<DropdownMenuItem<ListItem>>((ListItem value) {
                          return DropdownMenuItem<ListItem>(
                            value: value,
                            child: Text(value.name!),
                          );
                        }).toList(),
                      ),
                    )
                  ],
                )
              ],
            ),
          ),
          Container(
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: Row(
              children: [
                Column(
                  children: [
                    Container(
                      child: Icon(
                        Icons.location_city,
                        size: 35,
                        color: Colors.grey,
                      ),
                    )
                  ],
                ),
                Column(
                  children: [
                    Container(
                      child: Text("    City  ", style: TextStyle(fontSize: 20)),
                    )
                  ],
                ),
                Column(
                  children: [
                    Container(
                      child: DropdownButton(
                        style: Theme.of(context).textTheme.titleLarge,
                        hint: Text("Select City"),
                        value: _tmpCity,
                        items: data.map(
                          (item) {
                            return DropdownMenuItem<City>(
                              child: Text("${item.name}"),
                              value: item,
                            );
                          },
                        ).toList(),
                        onChanged: (City? value) {
                          setState(() {
                            _tmpCity = value;
                          });
                        },
                      ),
                    ),
                  ],
                )
              ],
            ),
          ),
          Container(
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _addressController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.location_city,
                    size: 35,
                  ),
                  hintText: 'Enter your address',
                  labelText: 'Address',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _birthDateController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.calendar_month,
                    size: 35,
                  ),
                  hintText: 'yyyy-mm-dd',
                  labelText: 'Birth date',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _emailController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.email,
                    size: 35,
                  ),
                  hintText: 'Enter your email',
                  labelText: 'Email',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _usernameController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.person,
                    size: 35,
                  ),
                  hintText: 'Enter your username',
                  labelText: 'Username',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _phoneNumberController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.phone,
                    size: 35,
                  ),
                  hintText: 'Enter your phone number',
                  labelText: 'Phone number',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              obscureText: true,
              style: Theme.of(context).textTheme.titleLarge,
              controller: _passwordController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.password,
                    size: 35,
                  ),
                  hintText: 'Enter your password',
                  labelText: 'Password',
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
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              obscureText: true,
              style: Theme.of(context).textTheme.titleLarge,
              controller: _passwordConfirmController,
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
                } else if (value != _passwordController.text) {
                  return 'Password confirm is not equal to Password';
                }
                return null;
              },
            ),
          ),
          SizedBox(height: 20),
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
                    var userna = _usernameController.text;
                    var client = await _userProvider?.getByUsername(userna);
                    if (client != null) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: Text("User already exist"),
                                content: Text(
                                    style:
                                        Theme.of(context).textTheme.subtitle2,
                                    "User already exist"),
                                actions: [
                                  TextButton(
                                      onPressed: () => Navigator.popUntil(
                                          context, (route) => route.isFirst),
                                      child: Text("Ok"))
                                ],
                              ));
                      return;
                    }
                    try {
                      PersonRequest _personData = new PersonRequest();
                      _personData.firstName = _firstNameController.text;
                      _personData.lastName = _lastNameController.text;
                      _personData.middleName = _middleNameController.text;
                      _personData.gender = genderValue.value;
                      _personData.cityId = _tmpCity?.id;
                      _personData.address = _addressController.text;
                      _personData.birthDate =
                          DateTime.parse(_birthDateController.text);

                      ApplicationUserRequest _appUserData =
                          new ApplicationUserRequest();
                      _appUserData.email = _emailController.text;
                      _appUserData.username = _usernameController.text;
                      _appUserData.phoneNumber = _phoneNumberController.text;
                      _appUserData.role = role;
                      _appUserData.password = _passwordController.text;
                      _appUserData.passwordConfirm =
                          _passwordConfirmController.text;

                      _clientData.active = true;
                      _clientData.person = _personData;
                      _clientData.user = _appUserData;

                      var user = await _userProvider!.insert(_clientData);
                      if (user != null) {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: Text("User registration successful!"),
                                  content: Text(
                                      style:
                                          Theme.of(context).textTheme.subtitle2,
                                      "Successfully registered user"),
                                  actions: [
                                    TextButton(
                                        onPressed: () => Navigator.popUntil(
                                            context, (route) => route.isFirst),
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
                                    style:
                                        Theme.of(context).textTheme.subtitle2,
                                    e.toString()),
                                actions: [
                                  TextButton(
                                      onPressed: () => Navigator.pop(context),
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
          SizedBox(height: 20),
        ]),
      ),
    );
  }
}
