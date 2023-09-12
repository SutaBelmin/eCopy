import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:myapp/model/city.dart';
import 'package:myapp/model/clientRequestUpdate.dart';
import 'package:myapp/model/listItem.dart';
import 'package:myapp/model/registrationModel/clientRequest.dart';
import 'package:myapp/model/registrationModel/response/clientResponse.dart';
import 'package:myapp/providers/city_provider.dart';
import 'package:myapp/providers/cl_provider.dart';
import 'package:myapp/providers/user_provider.dart';
import 'package:myapp/screens/loading_screen.dart';
import 'package:myapp/screens/pass_screen.dart';
import 'package:myapp/screens/print_list_screen.dart';
import 'package:myapp/widgets/master_widget.dart';
import 'package:provider/provider.dart';

class AccountScreen extends StatefulWidget {
  static const String routeName = "accountscreen";

  const AccountScreen({super.key});

  @override
  State<AccountScreen> createState() => _AccountScreenState();
}

class _AccountScreenState extends State<AccountScreen> {
  UserProvider? _userProvider = null;
  ClientRequest _clientData = new ClientRequest();
  CityProvider? _cityProvider = null;
  ClProvider? _clProvider = null;

  List<City> data = [];
  City? _tmpCity;

  var tmpclientData = null;

  ClientResponse? clientData = null;

  TextEditingController _firstNameController = new TextEditingController();
  TextEditingController _lastNameController = new TextEditingController();
  TextEditingController _middleNameController = new TextEditingController();
  TextEditingController _addressController = new TextEditingController();
  TextEditingController _birthDateController = new TextEditingController();
  TextEditingController _emailController = new TextEditingController();
  TextEditingController _usernameController = new TextEditingController();
  TextEditingController _phoneNumberController = new TextEditingController();
  TextEditingController _cityController = new TextEditingController();
  TextEditingController _postalController = new TextEditingController();
  TextEditingController _passwordController = new TextEditingController();
  TextEditingController _passwordConfirmController =
      new TextEditingController();

  final _formKey = GlobalKey<FormState>();

  static List<ListItem> gender = [ListItem(0, "Male"), ListItem(1, "Female")];
  ListItem genderValue = gender.first;

  var cityValue = null;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _cityProvider = context.read<CityProvider>();
    _userProvider = context.read<UserProvider>();
    _clProvider = context.read<ClProvider>();
    loadData();
  }

  Future loadData() async {
    tmpclientData = await _userProvider?.getClientAccount();

    var tmpData = await _cityProvider?.get(null);

    setState(() {
      clientData = tmpclientData;

      _firstNameController.text = clientData!.person!.firstName!;
      _lastNameController.text = clientData!.person!.lastName!;
      _middleNameController.text = clientData!.person!.middleName!;
      _addressController.text = clientData!.person!.address!;
      _cityController.text = clientData!.person!.city!.name!;
      _postalController.text = clientData!.person!.city!.postalCode.toString();

      DateTime birthDate = clientData!.person!.birthDate!;
      String formattedDate = DateFormat('yyyy-MM-dd').format(birthDate);
      _birthDateController.text = formattedDate;

      _emailController.text = clientData!.applicationUser!.email!;
      _usernameController.text = clientData!.applicationUser!.username!;
      _phoneNumberController.text = clientData!.applicationUser!.phoneNumber!;

      data = tmpData!;
    });
    _tmpCity =
        tmpData?.firstWhere((x) => x.name == clientData!.person!.city!.name);

    genderValue =
        gender.firstWhere((x) => x.name == clientData!.person!.gender);
  }

  @override
  Widget build(BuildContext context) {
    if (tmpclientData == null) {
      loadData();
      return LoadingScreen();
    } else {
      return MasterWidget(
          selectedIndex: 1,
          child: SingleChildScrollView(
            child: Form(
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
                              child: Text("    Gender  ",
                                  style: TextStyle(fontSize: 20)),
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
                                items: gender.map<DropdownMenuItem<ListItem>>(
                                    (ListItem value) {
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
                              child: Text("    City  ",
                                  style: TextStyle(fontSize: 20)),
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
                        if (value != null && value.isNotEmpty) {
                          try {
                            var dateParts = value.split("-");

                            var month = int.parse(dateParts[1]);
                            var day = int.parse(dateParts[2]);
                            var year = int.parse(dateParts[0]);

                            if (year.toString().length != 4) {
                              return 'Invalid format';
                            }
                            if ((month > 12 || month < 1) &&
                                (day > 31 || day < 1)) {
                              return 'Invalid month and day';
                            }
                            if (month > 12 || month < 1) {
                              return 'Invalid month';
                            }
                            if (day > 31 || day < 1) {
                              return 'Invalid day';
                            }

                            if (dateParts.length == 3) {
                              var selectedDate = DateTime(year, month, day);
                              var currentDate = DateTime.now();

                              if (selectedDate.isAfter(currentDate)) {
                                return 'Birth date can\'t be in the future';
                              }
                            } else {
                              return 'Invalid format';
                            }
                          } catch (e) {
                            print('Error parsing date: $e');
                            return 'Invalid format';
                          }
                        } else {
                          return 'Please enter a birth date';
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
                        if (!isEmailValid(value)) {
                          return 'Invalid email';
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
                        if (!isUsernameValid(value)) {
                          return 'Min length of 4 characters (letters and numbers)';
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
                        if (!isPhoneValid(value)) {
                          return '''Enter a valid Bosnian mobile phone number like: 
                        \n06X/XXX-XXX or 06X/XXX-XXXX
                        \n06X XXX XXX or 06X XXX XXXX
                        \n06X-XXX-XXX or 06X-XXX-XXXX''';
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
                            var userem = _emailController.text;
                            var client = await _clProvider?.GetByUsrnameOrEmail(
                                userna, userem);

                            if (client?.username == true) {
                              showDialog(
                                  context: context,
                                  builder: (BuildContext context) =>
                                      AlertDialog(
                                        title: Text("Username already exist"),
                                        content: Text(
                                            style: Theme.of(context)
                                                .textTheme
                                                .subtitle2,
                                            "Username already exist"),
                                        actions: [
                                          TextButton(
                                              onPressed: () {
                                                Navigator.of(context)
                                                    .pop(false);
                                              },
                                              child: Text("Ok"))
                                        ],
                                      ));
                              return;
                            }
                            if (client?.email == true) {
                              showDialog(
                                  context: context,
                                  builder: (BuildContext context) =>
                                      AlertDialog(
                                        title: Text("Email already exist"),
                                        content: Text(
                                            style: Theme.of(context)
                                                .textTheme
                                                .subtitle2,
                                            "Email already exist"),
                                        actions: [
                                          TextButton(
                                              onPressed: () {
                                                Navigator.of(context)
                                                    .pop(false);
                                              },
                                              child: Text("Ok"))
                                        ],
                                      ));
                              return;
                            }

                            try {
                              ClientRequestUpdate updateCl =
                                  new ClientRequestUpdate();

                              updateCl.firstName = _firstNameController.text;
                              updateCl.lastName = _lastNameController.text;
                              updateCl.middleName = _middleNameController.text;
                              updateCl.gender = genderValue.value;
                              updateCl.cityId = _tmpCity?.id;
                              updateCl.address = _addressController.text;
                              updateCl.birthDate =
                                  DateTime.parse(_birthDateController.text);
                              updateCl.email = _emailController.text;
                              updateCl.username = _usernameController.text;
                              updateCl.phoneNumber =
                                  _phoneNumberController.text;

                              var newCl =
                                  await _userProvider?.updateClient(updateCl);
                              if (newCl != null) {
                                showDialog(
                                    context: context,
                                    builder: (BuildContext context) =>
                                        AlertDialog(
                                          title:
                                              Text("User update successful!"),
                                          content: Text(
                                              style: Theme.of(context)
                                                  .textTheme
                                                  .subtitle2,
                                              "Successfully updated user"),
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
                          Navigator.pushNamed(
                              context, "${PassScreen.routeName}");
                        },
                        child: Center(
                            child: Text(
                          "Change Password",
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 16,
                          ),
                        )),
                      )),
                  SizedBox(height: 20),
                ]),
              ),
            ),
          ));
    }
  }

  bool isEmailValid(String email) {
    final pattern = r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$';
    final regExp = RegExp(pattern);
    return regExp.hasMatch(email);
  }

  bool isPhoneValid(String phone) {
    final pattern = r'^06\d{1}([-/ ])?\d{3}([- ])?\d{3,4}$';
    final regExp = RegExp(pattern);
    return regExp.hasMatch(phone);
  }

  bool isUsernameValid(String username) {
    final pattern = r'^[a-zA-Z0-9]{4,}$';

    final regExp = RegExp(pattern);
    return regExp.hasMatch(username);
  }

  bool isPasswordValid(String password) {
    final pattern = r'^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z]).{8,}$';

    final regExp = RegExp(pattern);
    return regExp.hasMatch(password);
  }
}
