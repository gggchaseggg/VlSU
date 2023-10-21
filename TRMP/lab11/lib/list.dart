import 'dart:math' as math;

import 'package:flutter/material.dart';

class BookListWidget extends StatefulWidget {
  final List<BookListItem> items;

  const BookListWidget({Key? key, required this.items}) : super(key: key);

  @override
  State<StatefulWidget> createState() {
    return ListWidget(items);
  }
}

class ListWidget extends State<BookListWidget> {
  List<BookListItem> items;

  ListWidget(this.items);

  void filterItems(int id) => () {
        setState(() {
          items = items.where((element) => element.id != id).toList();
        });
      };

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: items.length,
      itemBuilder: (context, index) {
        final item = items[index];
        return BookItemWidget(
          key: ValueKey(item.id),
          item: item,
          filterItems: filterItems,
        );
      },
    );
  }
}

class BookListItem {
  final int id;
  final String path;
  final String title;
  final String description;

  BookListItem(this.id, this.path, this.title, this.description);
}

class BookItemWidget extends StatefulWidget {
  final BookListItem item;
  final Function(int id) filterItems;

  const BookItemWidget(
      {super.key, required this.item, required this.filterItems});

  @override
  State<StatefulWidget> createState() {
    return BookItemState(item: item, filterItems: filterItems);
  }
}

class BookItemState extends State<BookItemWidget> {
  Color bgColor = Colors.transparent;
  BookListItem item;
  final Function(int id) filterItems;

  BookItemState({required this.item, required this.filterItems});

  void changeColor() {
    setState(() {
      bgColor = Color((math.Random().nextDouble() * 0xFFFFFF).toInt())
          .withOpacity(1.0);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        border: const Border(bottom: BorderSide(color: Colors.black, width: 1)),
        color: bgColor,
      ),
      padding: const EdgeInsets.symmetric(vertical: 15),
      child: TextButton(
        onPressed: changeColor,
        onLongPress: filterItems(item.id),
        child: Row(
          mainAxisSize: MainAxisSize.min,
          children: [
            Image.asset(
              item.path,
              width: 150,
              height: 150,
            ),
            Expanded(
              child: ListTile(
                title: Text(item.title),
                subtitle: Text(item.description),
                minLeadingWidth: 100,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
