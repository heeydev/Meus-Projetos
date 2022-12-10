<?php

require 'Produto.php';

$produto = new Produto();

$produto->list();

switch ($_GET['operacao']) {

    case 'list':

        echo "<h3>Produtos: </h3>";

        foreach ($produto->list() as $value) {
            echo 'Id: ' . $value['id'] . '<br> Descrição: ' . $value['descricao'] . '<hr>';
        }

        break;

    case 'insert':

        $status = $produto->insert('Produto Teste do Hiago Crespo 01');

        if (!$status) {
            echo 'Não foi possível executar a operação!';
            return false;
        }

        echo 'Registro inserido com sucesso!';

        break;

    case 'update':
        $status = $produto->update('Produto Alterado do Hiago Crespo', 1);

        if (!$status) {
            echo 'Não foi possível executar a operação!';
            return false;
        }

        echo 'Registro inserido com sucesso!';

        break;
    case 'delete':
        $status = $produto->delete(3);

        if (!$status) {
            echo 'Não foi possível executar a operação!';
            return false;
        }

        echo 'Registro removido com sucesso!';

        break;
}
