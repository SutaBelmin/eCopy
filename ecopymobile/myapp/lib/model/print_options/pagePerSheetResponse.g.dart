// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pagePerSheetResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PagePerSheetResponse _$PagePerSheetResponseFromJson(
        Map<String, dynamic> json) =>
    PagePerSheetResponse()
      ..id = json['id'] as int?
      ..name = json['name'] as String?
      ..isActive = json['isActive'] as bool?;

Map<String, dynamic> _$PagePerSheetResponseToJson(
        PagePerSheetResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'isActive': instance.isActive,
    };
