import 'dart:ffi';
import 'package:json_annotation/json_annotation.dart';
import 'package:myapp/model/registrationModel/response/applicationUserResponse.dart';
import 'package:myapp/model/registrationModel/response/personResponse.dart';

part 'clientResponse.g.dart';

@JsonSerializable()
class ClientResponse {
  int? id;
  ApplicationUserResponse? applicationUser;
  PersonResponse? person;
  int? personId;
  int? applicationUserId;

  ClientResponse() {}

  factory ClientResponse.fromJson(Map<String, dynamic> json) =>
      _$ClientResponseFromJson(json);

  /// Connect the generated [_$ClientResponseToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ClientResponseToJson(this);
}
