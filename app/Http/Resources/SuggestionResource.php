<?php

namespace App\Http\Resources;

use Illuminate\Http\Request;
use Illuminate\Http\Resources\Json\JsonResource;

class SuggestionResource extends JsonResource
{
    public function toArray(Request $request): array
    {
        return [
            'id' => $this->id,
            'user' => [
                'id' => $this->user->id,
                'name' => $this->user->name,
            ],
            'title' => $this->title,
            'youtube_url' => $this->youtube_url,
            'is_approved' => $this->is_approved,
            'created_at' => $this->created_at->toDateTimeString(),
        ];
    }
}
