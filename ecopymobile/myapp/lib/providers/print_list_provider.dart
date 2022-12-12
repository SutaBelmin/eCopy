/*import 'package:flutter/cupertino.dart';

class PrintListProvider with ChangeNotifier {
  Future<dynamic> get(dynamic searchObject) async {
    return "Test";
  }
}*/

//import 'package:myapp/model/request.dart';
import 'package:myapp/providers/base_provider.dart';

import '../model/zahtjev.dart';

class PrintListProvider extends BaseProvider<Zahtjev> {
  PrintListProvider() : super("PrintRequest");

  /*@override
  Request fromJson(data) {
    // TODO: implement fromJson
    return Request.fromJson(data);
  }*/

  @override
  Zahtjev fromJson(data) {
    // TODO: implement fromJson
    return Zahtjev.fromJson(data);
  }
}
