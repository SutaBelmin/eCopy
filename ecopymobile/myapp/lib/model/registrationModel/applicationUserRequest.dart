import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'applicationUserRequest.g.dart';

@JsonSerializable()
class ApplicationUserRequest {
  String? email;
  String? username;
  String? phoneNumber;
  //String? role;
  int? role;
  String? password;
  String? passwordConfirm;

  ApplicationUserRequest() {}

  factory ApplicationUserRequest.fromJson(Map<String, dynamic> json) =>
      _$ApplicationUserRequestFromJson(json);

  /// Connect the generated [_$ApplicationUserRequestToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ApplicationUserRequestToJson(this);
}
