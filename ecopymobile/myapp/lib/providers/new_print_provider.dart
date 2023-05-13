import 'package:flutter/cupertino.dart';

class NewPrintProvider with ChangeNotifier {
  Future<dynamic> get(dynamic searchObject) async {
    return "New test";
  }
}
