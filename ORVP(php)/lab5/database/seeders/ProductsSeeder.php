<?php

namespace Database\Seeders;
use DB;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class ProductsSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        DB::table('products')->insert([
            'name' => 'LG',
            'description' => 'Protection Corning Gorilla Glass 4. MISC Colors Space Black, Luxe White, Modern Beige, Ocean Blue, Opal Blue.',
            'photo' => 'https://i.ebayimg.com/00/s/NjQxWDQyNA==/z/VDoAAOSwgk1XF2oo/$_35.JPG?set_id=89040003C1',
            'price' => 3999
        ]);
        DB::table('products')->insert([
            'name' => 'Samsung',
            'description' => 'S22 Ultra 5G 6.7"HD Smart Phone 6800mAh Face ID Android 4+64+128GB TF Card',
            'photo' => 'https://i.ebayimg.com/images/g/AQgAAOSwDkViWTQe/s-l500.jpg',
            'price' => 7999
        ]);
        DB::table('products')->insert([
            'name' => 'Google',
            'description' => 'Google Pixel 6 - 128GB - Sorta Seafoam (Google Ed. and Unlocked)',
            'photo' => 'https://i.ebayimg.com/images/g/6Z0AAOSwCmJjRcc8/s-l1600.jpg',
            'price' => 1826
        ]);
        DB::table('products')->insert([
            'name' => 'Samsung Folder',
            'description' => 'Samsung Galaxy Folder 2 SM-G1650 dual-SIM Android Mobile Flip Phone 4G LTE 8MP',
            'photo' => 'https://i.ebayimg.com/images/g/uKIAAOSwfURdIhAq/s-l500.jpg',
            'price' => 1012
        ]);
        DB::table('products')->insert([
            'name' => 'Apple',
            'description' => 'Apple iPhone X 64 and 256 - Back and Silver NO FACE ID-',
            'photo' => 'https://i.ebayimg.com/images/g/hDAAAOSwqgpjrV76/s-l1600.jpg',
            'price' => 1171
        ]);
        DB::table('products')->insert([
            'name' => 'LG',
            'description' => 'LG Wine Smart D486 4G LTE 4GB ROM 3.5" Android Flip Keyboard Unlocked Smartphone',
            'photo' => 'https://i.ebayimg.com/images/g/73EAAOSwDfFjrRFF/s-l1600.jpg',
            'price' => 6209
        ]);
          
    }
}
