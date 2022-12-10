<?php

require 'Blog.php';

$post = new Blog();

$post->list();

switch ($_GET['operacao']) {

    case 'list':

        echo "<h3>Posts: </h3>";

        foreach ($post->list() as $value) {
            echo 'Id: ' . $value['id'] .'<br> Título: ' . $value['titulo'] . '<br> Descrição: ' . $value['descricao'] .'<br> Autor: ' . $value['autor'] . '<hr>';
        }

        break;

    case 'insert':

        $status = $post->insert("Titulo Teste", "Descricao Teste", "Autor Teste");

        if (!$status) {
            echo 'Não foi possível executar a operação!';
            return false;
        }

        echo 'Registro inserido com sucesso!';

        break;

    case 'update':
        $status = $post->update("Titulo Alterado Teste", "Descricao Alterado Teste", "Autor Alterado Teste", 4);

        if (!$status) {
            echo 'Não foi possível executar a operação!';
            return false;
        }

        echo 'Registro alterado com sucesso!';

        break;

    case 'delete':
        $status = $post->delete(4);

        if (!$status) {
            echo 'Não foi possível executar a operação!';
            return false;
        }

        echo 'Registro removido com sucesso!';

        break;
}