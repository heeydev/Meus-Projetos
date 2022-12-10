<?php

declare(strict_types=1);

class Blog
{

    /**
     * @var PDO
     */

    private $conexao;

    public function __construct()
    {

        try {
            $this->conexao = new PDO('mysql:host=localhost;dbname=blog', 'root', '12345');
        } catch (Exception $e) {
            echo $e->getMessage();
            die();
        }
    }

    public function list(): array
    {
        $sql = 'select * from posts';

        $posts = [];

        foreach ($this->conexao->query($sql) as $key => $value) {
            array_push($posts, $value);
        }

        return $posts;
    }

    public function insert(string $titulo, string $descricao, string $autor): int
    {
        $sql = 'insert into posts (titulo, descricao, autor) values(?, ?, ?)';

        $prepare = $this->conexao->prepare($sql);

        $prepare->bindParam(1, $titulo);
        $prepare->bindParam(2, $descricao);
        $prepare->bindParam(3, $autor);
        $prepare->execute();

        return $prepare->rowCount();
    }

    public function update(string $titulo, string $descricao, string $autor, int $id): int
    {
        $sql = 'update posts set titulo=?, descricao=?, autor=? where id = ?';

        $prepare = $this->conexao->prepare($sql);


        $prepare->bindParam(1, $titulo);
        $prepare->bindParam(2, $descricao);
        $prepare->bindParam(3, $autor);
        $prepare->bindParam(4, $id);

        $prepare->execute([$titulo, $descricao, $autor, $id]);

        return $prepare->rowCount();
    }

    public function delete($id): int
    {
        $sql = 'delete from posts where id = ?';

        $prepare = $this->conexao->prepare($sql);

        $prepare->bindParam(1, $id);
        $prepare->execute();

        return $prepare->rowCount();
    }
}
