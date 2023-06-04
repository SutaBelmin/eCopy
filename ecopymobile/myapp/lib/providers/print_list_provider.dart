import 'package:myapp/model/printRequest.dart';
import 'package:myapp/providers/base_provider.dart';

class PrintListProvider extends BaseProvider<PrintRequest> {
  PrintListProvider() : super("PrintRequest");
  @override
  PrintRequest fromJson(data) {
    // TODO: implement fromJson
    return PrintRequest.fromJson(data);
  }
}
