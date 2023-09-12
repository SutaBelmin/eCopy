import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'request.g.dart';

@JsonSerializable()
class Request {
  String? id;
  int? status;
  int? collatedPrintOptionId;
  int? orientationId;
  int? letterId;
  int? pagePerSheetId;
  int? printPageOptionId;
  int? sidePrintOptionId;
  double? price;
  String? comment;
  bool? isPaid;

  Request() {}

  factory Request.fromJson(Map<String, dynamic> json) =>
      _$RequestFromJson(json);

  /// Connect the generated [_$RequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RequestToJson(this);
}
