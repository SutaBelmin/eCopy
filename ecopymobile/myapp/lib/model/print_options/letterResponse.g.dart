// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'letterResponse.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

LetterResponse _$LetterResponseFromJson(Map<String, dynamic> json) =>
    LetterResponse()
      ..id = json['id'] as int?
      ..name = json['name'] as String?
      ..isActive = json['isActive'] as bool?;

Map<String, dynamic> _$LetterResponseToJson(LetterResponse instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'isActive': instance.isActive,
    };
