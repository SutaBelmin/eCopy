import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';
import 'package:myapp/model/registrationModel/response/cityResponse.dart';

part 'personResponse.g.dart';

@JsonSerializable()
class PersonResponse {
  int? id;
  String? firstName;
  String? lastName;
  String? middleName;
  String? gender;
  int? cityId;
  CityResponse? city;
  String? address;
  DateTime? birthDate;

  PersonResponse() {}

  factory PersonResponse.fromJson(Map<String, dynamic> json) =>
      _$PersonResponseFromJson(json);

  /// Connect the generated [_$PersonResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$PersonResponseToJson(this);
}
