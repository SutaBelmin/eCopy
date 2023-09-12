import 'dart:convert';

import 'package:myapp/model/paymentModel.dart';
import 'package:myapp/model/request.dart';
import 'package:myapp/model/requestUpd.dart';
import 'package:myapp/providers/base_provider.dart';

class RequestProvider extends BaseProvider<Request> {
  RequestProvider() : super("PrintRequest");

  @override
  Request fromJson(data) {
    // TODO: implement fromJson
    return Request.fromJson(data);
  }

  Future<Request?> pay(String id, PaymentModel stripePaymentModel) async {
    //var url = "https://10.0.2.2:7284/PrintRequest/Pay/${id}";

    //var url = "http://10.0.2.2:5000/PrintRequest/Pay/${id}";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}PrintRequest/Pay/${id}";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!
        .post(uri, body: jsonEncode(stripePaymentModel), headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }

  Future<bool?> cancelRequest(String id) async {
    //var url = "https://10.0.2.2:7284/PrintRequest/CancelRequest/${id}";

    //var url = "http://10.0.2.2:5000/PrintRequest/CancelRequest/${id}";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}PrintRequest/CancelRequest/${id}";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response = await http!.put(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return true;
    } else {
      return false;
    }
  }

  Future<Request?> updateRequest(String id, RequestUpd update) async {
    //var url = "https://10.0.2.2:7284/PrintRequest/UpdateRequest/$id";

    //var url = "http://10.0.2.2:5000/PrintRequest/UpdateRequest/${id}";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}PrintRequest/UpdateRequest/${id}";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();
    var response =
        await http!.put(uri, body: jsonEncode(update), headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      return null;
    }
  }
}
