import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'requestUpd.g.dart';

@JsonSerializable()
class RequestUpd {
  int? status;
  int? collatedPrintOptionId;
  int? orientationId;
  int? letterId;
  int? pagePerSheetId;
  int? printPageOptionId;
  int? sidePrintOptionId;

  RequestUpd() {}

  factory RequestUpd.fromJson(Map<String, dynamic> json) =>
      _$RequestUpdFromJson(json);

  /// Connect the generated [_$RequestUpdToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RequestUpdToJson(this);
}
