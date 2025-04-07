<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    
    public function up(): void {
        Schema::table('suggestions', function (Blueprint $table) {
            $table->dropColumn('is_approved');
            $table->enum('status', ['pending', 'approved', 'rejected'])->default('pending')->after('youtube_url');
        });
    }

    public function down(): void {
        Schema::table('suggestions', function (Blueprint $table) {
            $table->dropColumn('status');
            $table->boolean('is_approved')->default(false)->after('youtube_url');
        });
    }
};
