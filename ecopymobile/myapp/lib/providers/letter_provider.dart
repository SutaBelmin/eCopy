import 'dart:convert';

import 'package:myapp/providers/base_provider.dart';
import 'package:myapp/model/print_options/letterResponse.dart';

class LetterProvider extends BaseProvider<LetterResponse> {
  LetterProvider() : super("Letter");

  @override
  LetterResponse fromJson(data) {
    // TODO: implement fromJson
    return LetterResponse.fromJson(data);
  }

  Future<List<LetterResponse>> GetActive() async {
    //var url = "https://10.0.2.2:7284/Letter/GetActive";

    var urlM = const String.fromEnvironment("baseUrl",
        defaultValue: "http://10.0.2.2:5000/");
    var url = "${urlM}Letter/GetActive";

    var uri = Uri.parse(url);

    Map<String, String> headers = createHeaders();

    var response = await http!.get(uri, headers: headers);

    if (isValidResponseCode(response)) {
      var data = jsonDecode(response.body);
      return data.map((x) => fromJson(x)).cast<LetterResponse>().toList();
    } else {
      throw Exception("Exception... handle this gracefully");
    }
  }
}
