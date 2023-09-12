// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'requestUpd.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RequestUpd _$RequestUpdFromJson(Map<String, dynamic> json) => RequestUpd()
  ..status = json['status'] as int?
  ..collatedPrintOptionId = json['collatedPrintOptionId'] as int?
  ..orientationId = json['orientationId'] as int?
  ..letterId = json['letterId'] as int?
  ..pagePerSheetId = json['pagePerSheetId'] as int?
  ..printPageOptionId = json['printPageOptionId'] as int?
  ..sidePrintOptionId = json['sidePrintOptionId'] as int?;

Map<String, dynamic> _$RequestUpdToJson(RequestUpd instance) =>
    <String, dynamic>{
      'status': instance.status,
      'collatedPrintOptionId': instance.collatedPrintOptionId,
      'orientationId': instance.orientationId,
      'letterId': instance.letterId,
      'pagePerSheetId': instance.pagePerSheetId,
      'printPageOptionId': instance.printPageOptionId,
      'sidePrintOptionId': instance.sidePrintOptionId,
    };
