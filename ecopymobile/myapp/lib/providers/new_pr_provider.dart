import 'package:myapp/model/printRequest.dart';
import 'package:myapp/providers/base_provider.dart';

class NewPrProvider extends BaseProvider<PrintRequest> {
  //treba ovde biti PrintResponse
  NewPrProvider() : super("PrintRequest");
  @override
  PrintRequest fromJson(data) {
    // TODO: implement fromJson
    return PrintRequest.fromJson(data);
  }
}
