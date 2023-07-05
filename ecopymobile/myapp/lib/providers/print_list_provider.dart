import 'dart:convert';

import 'package:myapp/model/printRequest.dart';
import 'package:myapp/providers/base_provider.dart';

class PrintListProvider extends BaseProvider<PrintRequest> {
  PrintListProvider() : super("PrintRequest");
  @override
  PrintRequest fromJson(data) {
    // TODO: implement fromJson
    return PrintRequest.fromJson(data);
  }

  Future<PrintRequest?> pay(String id) async {
    var url = "http://10.0.2.2:5000/PrintRequest/Pay/${id}";
    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.post(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }
}
