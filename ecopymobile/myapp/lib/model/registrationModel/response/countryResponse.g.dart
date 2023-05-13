// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'countryResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CountryResponse _$CountryResponseFromJson(Map<String, dynamic> json) =>
    CountryResponse()
      ..id = json['id'] as int?
      ..name = json['name'] as String?
      ..shortName = json['shortName'] as String?
      ..phoneNumberCode = json['phoneNumberCode'] as String?
      ..phoneNumberRegex = json['phoneNumberRegex'] as String?
      ..active = json['active'] as bool?;

Map<String, dynamic> _$CountryResponseToJson(CountryResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'shortName': instance.shortName,
      'phoneNumberCode': instance.phoneNumberCode,
      'phoneNumberRegex': instance.phoneNumberRegex,
      'active': instance.active,
    };
