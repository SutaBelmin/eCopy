import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'requestResponse.g.dart';

@JsonSerializable()
class RequestResponse {
  String? id;
  int? status;
  int? side;
  int? options;
  int? orientation;
  int? letter;
  int? collate;
  int? pagePerSheet;
  double? price;

  RequestResponse() {}

  factory RequestResponse.fromJson(Map<String, dynamic> json) =>
      _$RequestResponseFromJson(json);

  /// Connect the generated [_$RequestResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RequestResponseToJson(this);
}
