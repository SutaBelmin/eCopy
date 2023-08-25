// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'clientRequestUpdate.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ClientRequestUpdate _$ClientRequestUpdateFromJson(Map<String, dynamic> json) =>
    ClientRequestUpdate()
      ..active = json['active'] as bool?
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..middleName = json['middleName'] as String?
      ..gender = json['gender'] as int?
      ..cityId = json['cityId'] as int?
      ..address = json['address'] as String?
      ..birthDate = json['birthDate'] == null
          ? null
          : DateTime.parse(json['birthDate'] as String)
      ..email = json['email'] as String?
      ..username = json['username'] as String?
      ..phoneNumber = json['phoneNumber'] as String?;

Map<String, dynamic> _$ClientRequestUpdateToJson(
        ClientRequestUpdate instance) =>
    <String, dynamic>{
      'active': instance.active,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'middleName': instance.middleName,
      'gender': instance.gender,
      'cityId': instance.cityId,
      'address': instance.address,
      'birthDate': instance.birthDate?.toIso8601String(),
      'email': instance.email,
      'username': instance.username,
      'phoneNumber': instance.phoneNumber,
    };
