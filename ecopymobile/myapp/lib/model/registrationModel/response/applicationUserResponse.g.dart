// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'applicationUserResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ApplicationUserResponse _$ApplicationUserResponseFromJson(
        Map<String, dynamic> json) =>
    ApplicationUserResponse()
      ..id = json['id'] as int?
      ..email = json['email'] as String?
      ..username = json['username'] as String?
      ..phoneNumber = json['phoneNumber'] as String?
      ..phoneNumberConfirmed = json['phoneNumberConfirmed'] as bool?
      ..emailConfirmed = json['emailConfirmed'] as bool?
      ..changePassword = json['changePassword'] as bool?
      ..twoFactorEnabled = json['twoFactorEnabled'] as bool?
      ..active = json['active'] as bool?;

Map<String, dynamic> _$ApplicationUserResponseToJson(
        ApplicationUserResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'email': instance.email,
      'username': instance.username,
      'phoneNumber': instance.phoneNumber,
      'phoneNumberConfirmed': instance.phoneNumberConfirmed,
      'emailConfirmed': instance.emailConfirmed,
      'changePassword': instance.changePassword,
      'twoFactorEnabled': instance.twoFactorEnabled,
      'active': instance.active,
    };
