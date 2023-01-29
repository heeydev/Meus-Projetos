<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class BandController extends Controller
{
    //Busca todas as bandas armazenadas
    public function getAll() {

        $bands = $this->getBands();

        return response()->json([$bands]);
    }

    //Busca as bandas pelo gênero
    public function getBandsByGender ($gender) {

        dd($gender);

        $band = [];

        foreach ($this->getBands() as $_band) {
            if ($_band['gender'] == $gender) {
                $band[] = $_band;
            }
        }

        return $band ? response()->json($band) : abort(code:404);
    }

    //Adiciona uma nova banda
    public function store(Request $request) {

        $validate = $request->validate([
            'id' => 'numeric|integer|gt:-1|min:0',
            'name' => 'required|min:3|max:40',
            'gender' => 'required|min:1|max:40'
        ]);

        return response()->json($request->all());
    }

    //Busca uma banda pelo ID
    protected function getById($id) {

        $band = null;

        foreach ($this->getBands() as $_band) {
            if ($_band['id'] == $id) {
                $band = $_band;
            }
        }

        return $band ? response()->json($band) : abort(code:404);
    }

    //Listagem das bandas armazenadas como dados para alimentação
    protected function getBands() {
        return [
            [
                'id' => 1, 'name' => 'dream teather', 'gender' => 'progressivo'
            ],
            [
                'id' => 2, 'name' => 'megadeth', 'gender' => 'trash metal'
            ],
            [
                'id' => 3, 'name' => 'dio', 'gender' => 'heavy metal'
            ],
            [
                'id' => 4, 'name' => 'metallica', 'gender' => 'heavy metal'
            ],
            [
                'id' => 5, 'name' => 'barões da pisadinha', 'gender' => 'tecno forró'
            ],

        ];
    }
}
