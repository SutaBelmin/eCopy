import 'package:myapp/model/registrationModel/applicationUserRequest.dart';
import 'package:myapp/model/registrationModel/personRequest.dart';

import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'clientRequest.g.dart';

@JsonSerializable()
class ClientRequest {
  bool? active;
  PersonRequest? person;
  ApplicationUserRequest? user;

  ClientRequest() {}

  factory ClientRequest.fromJson(Map<String, dynamic> json) =>
      _$ClientRequestFromJson(json);

  /// Connect the generated [_$ClientRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ClientRequestToJson(this);
}
