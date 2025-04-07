<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use Illuminate\Support\Facades\DB;

class TopFiveMusicsSeeder extends Seeder
{
    public function run(): void
    {
        DB::table('musics')->insert([
            ['title' => 'O Mineiro e o Italiano', 'youtube_url' => 'https://www.youtube.com/watch?v=s9kVG2ZaTS4'],
            ['title' => 'Pagode em Brasília', 'youtube_url' => 'https://www.youtube.com/watch?v=lpGGNA6_920'],
            ['title' => 'Terra roxa', 'youtube_url' => 'https://www.youtube.com/watch?v=4Nb89GFu2g4'],
            ['title' => 'Tristeza do Jeca', 'youtube_url' => 'https://www.youtube.com/watch?v=tRQ2PWlCcZk'],
            ['title' => 'Rio de Lágrimas', 'youtube_url' => 'https://www.youtube.com/watch?v=FxXXvPL3JIg'],
        ]);
    }
}

