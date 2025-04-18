<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    public function up(): void {
        Schema::create('musics', function (Blueprint $table) {
            $table->id();
            $table->string('title');
            $table->string('youtube_url');
            $table->unsignedInteger('plays')->default(0);
            $table->timestamps();
        });
    }

    public function down(): void {
        Schema::dropIfExists('musics');
    }
};
