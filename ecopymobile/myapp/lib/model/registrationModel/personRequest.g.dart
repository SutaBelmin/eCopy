// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'personRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PersonRequest _$PersonRequestFromJson(Map<String, dynamic> json) =>
    PersonRequest()
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..middleName = json['middleName'] as String?
      ..gender = json['gender'] as int?
      ..cityId = json['cityId'] as int?
      ..address = json['address'] as String?
      ..birthDate = json['birthDate'] == null
          ? null
          : DateTime.parse(json['birthDate'] as String);

Map<String, dynamic> _$PersonRequestToJson(PersonRequest instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'middleName': instance.middleName,
      'gender': instance.gender,
      'cityId': instance.cityId,
      'address': instance.address,
      'birthDate': instance.birthDate?.toIso8601String(),
    };
