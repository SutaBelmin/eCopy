class RequestArguments {
  String? id;
  int? status;
  int? side;
  int? options;
  int? orientation;
  int? letter;
  int? collate;
  int? pages;
  double? price;
  bool? isPaid;

  RequestArguments(
      this.id,
      this.status,
      this.side,
      this.options,
      this.orientation,
      this.letter,
      this.collate,
      this.pages,
      this.price,
      this.isPaid);
}
