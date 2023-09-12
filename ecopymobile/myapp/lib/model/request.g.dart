// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Request _$RequestFromJson(Map<String, dynamic> json) => Request()
  ..id = json['id'] as String?
  ..status = json['status'] as int?
  ..collatedPrintOptionId = json['collatedPrintOptionId'] as int?
  ..orientationId = json['orientationId'] as int?
  ..letterId = json['letterId'] as int?
  ..pagePerSheetId = json['pagePerSheetId'] as int?
  ..printPageOptionId = json['printPageOptionId'] as int?
  ..sidePrintOptionId = json['sidePrintOptionId'] as int?
  ..price = (json['price'] as num?)?.toDouble()
  ..comment = json['comment'] as String?
  ..isPaid = json['isPaid'] as bool?;

Map<String, dynamic> _$RequestToJson(Request instance) => <String, dynamic>{
      'id': instance.id,
      'status': instance.status,
      'collatedPrintOptionId': instance.collatedPrintOptionId,
      'orientationId': instance.orientationId,
      'letterId': instance.letterId,
      'pagePerSheetId': instance.pagePerSheetId,
      'printPageOptionId': instance.printPageOptionId,
      'sidePrintOptionId': instance.sidePrintOptionId,
      'price': instance.price,
      'comment': instance.comment,
      'isPaid': instance.isPaid,
    };
