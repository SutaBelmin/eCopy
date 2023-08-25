import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:myapp/model/city.dart';
import 'package:myapp/model/cityAddModel.dart';
import 'package:myapp/model/listItem.dart';
import 'package:myapp/model/registrationModel/applicationUserRequest.dart';
import 'package:myapp/model/registrationModel/clientRequest.dart';
import 'package:myapp/model/registrationModel/personRequest.dart';
import 'package:myapp/providers/city_provider.dart';
import 'package:myapp/providers/cl_provider.dart';
import 'package:myapp/providers/user_provider.dart';
import 'package:myapp/widgets/top_navigation_bar.dart';
import 'package:provider/provider.dart';

class RegistrationScreen extends StatefulWidget {
  static const String routeName = "registrationscreen";
  const RegistrationScreen({super.key});

  @override
  State<RegistrationScreen> createState() => _RegistrationScreenState();
}

class _RegistrationScreenState extends State<RegistrationScreen> {
  UserProvider? _userProvider = null;

  ClProvider? _clProvider = null;

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
  TextEditingController _cityController = new TextEditingController();
  TextEditingController _postalController = new TextEditingController();
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

    _clProvider = context.read<ClProvider>();

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

  bool passwordVisible = false;
  bool passwordConVisible = false;

  @override
  Widget build(BuildContext context) {
    return TopNavigationBar(
        child: SingleChildScrollView(child: _buildRegisterForm()));
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
            child: TextFormField(
              style: Theme.of(context).textTheme.titleLarge,
              controller: _cityController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.location_city,
                    size: 35,
                  ),
                  hintText: 'Enter city name',
                  labelText: 'City',
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
              controller: _postalController,
              decoration: InputDecoration(
                  border: OutlineInputBorder(),
                  icon: Icon(
                    Icons.location_city,
                    size: 35,
                  ),
                  hintText: 'Enter postal code',
                  labelText: 'Postal code',
                  isDense: true,
                  contentPadding: EdgeInsets.all(10)),
              keyboardType: TextInputType.number,
              inputFormatters: <TextInputFormatter>[
                FilteringTextInputFormatter.digitsOnly
              ],
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
                    if ((month > 12 || month < 1) && (day > 31 || day < 1)) {
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
          Container(
            padding: EdgeInsets.only(left: 30, top: 30, right: 30),
            child: TextFormField(
              obscureText: !passwordVisible,
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
                  return 'Password and Password confirm do not match';
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
                    var client =
                        await _clProvider?.GetByUsrnameOrEmail(userna, userem);

                    if (client?.username == true) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: Text("Username already exist"),
                                content: Text(
                                    style:
                                        Theme.of(context).textTheme.subtitle2,
                                    "Username already exist"),
                                actions: [
                                  TextButton(
                                      onPressed: () {
                                        Navigator.of(context).pop(false);
                                      },
                                      child: Text("Ok"))
                                ],
                              ));
                      return;
                    }
                    if (client?.email == true) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: Text("Email already exist"),
                                content: Text(
                                    style:
                                        Theme.of(context).textTheme.subtitle2,
                                    "Email already exist"),
                                actions: [
                                  TextButton(
                                      onPressed: () {
                                        Navigator.of(context).pop(false);
                                      },
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

                      var cityName = _cityController.text;
                      var postalCode = int.parse(_postalController.text);

                      CityAddModel cmodel = new CityAddModel();
                      cmodel.name = cityName;
                      cmodel.shortName = cityName;
                      cmodel.postalCode = postalCode;
                      cmodel.countryID = 1;
                      cmodel.active = true;

                      var cityE = await _cityProvider?.insert(cmodel);

                      if (cityE != null) {
                        var cityId = cityE.id;
                        _clientData.person?.cityId = cityId;
                      }

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
