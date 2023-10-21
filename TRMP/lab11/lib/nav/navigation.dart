import 'package:flutter/material.dart';

import 'package:lab11/image.dart';
import 'package:lab11/list.dart';

class Home extends StatefulWidget {
  const Home({super.key});

  @override
  State<StatefulWidget> createState() {
    return _HomeState();
  }
}

class _HomeState extends State<Home> {
  int _currentIndex = 1;
  final List<Widget> _children = [
    RandomImageWidget(),
    DogImage(),
    BookListWidget(items: <BookListItem>[
      BookListItem(0, 'assets/War.jpg', 'Война и мир', 'Лев Николаевич Толстой'),
      BookListItem(1, 'assets/daughter.jpeg', 'Капитанская дочка', 'Александр Сергеевич Пушкин'),
      BookListItem(2, 'assets/povest.jpg', 'Повесть о настоящем человеке', 'Борис Николаевич Полевой'),
      BookListItem(3, 'assets/nakaz.jpg', 'Преступление и наказание', 'Федор Михайлович Достоевский'),
      BookListItem(4, 'assets/dev.jpg', '1984', 'Джордж Оруэлл'),
    ])
  ];

  void onTabTapped(int index) {
    setState(() {
      _currentIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('My Flutter App'),
      ),
      body: _children[_currentIndex],
      bottomNavigationBar: BottomNavigationBar(
        onTap: onTabTapped,
        currentIndex: _currentIndex,
        items: const [
          BottomNavigationBarItem(
            icon: Icon(Icons.image_outlined),
            label: 'Картинка',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.adb),
            label: 'Собачка',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.list),
            label: 'Список',
          ),
        ],
      ),
    );
  }
}

class PlaceholderWidget extends StatelessWidget {
  final Color color;

  const PlaceholderWidget(this.color, {super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: color,
    );
  }
}
