<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory;

class Suggestion extends Model
{
    use HasFactory;

    protected $fillable = [
        'user_id',
        'title',
        'youtube_url',
        'status',
    ];

    public function user()
    {
        return $this->belongsTo(User::class);
    }
}
