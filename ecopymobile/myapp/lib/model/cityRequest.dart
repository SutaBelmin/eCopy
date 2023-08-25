import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'cityRequest.g.dart';

@JsonSerializable()
class CityRequest {
  String? name;
  String? shortName;
  int? postalCode;
  int? countryID;
  bool? active;

  CityRequest() {}

  factory CityRequest.fromJson(Map<String, dynamic> json) =>
      _$CityRequestFromJson(json);

  /// Connect the generated [_$CityRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$CityRequestToJson(this);
}
