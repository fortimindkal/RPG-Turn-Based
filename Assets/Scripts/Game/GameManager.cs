using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Unit Prefabs")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [Header("Unit Position")]
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform enemyPosition;

    [Header("Unit Controller")]
    [SerializeField] private UnitController playerUnit;
    [SerializeField] private UnitController enemyUnit;

    [Header("Unit HUD")]
    [SerializeField] private HUDController playerHUD;
    [SerializeField] private HUDController enemyHUD;

    [Header("")]
    [SerializeField] private GameObject playerParticle;
    [SerializeField] private GameObject enemyParticle;

    [Header("Battle Interface")]
    [SerializeField] private Button attackButton;
    [SerializeField] private Button defendButton;
    [SerializeField] private Button skillButton;
    [SerializeField] private SkillController skillController;
    [SerializeField] private ResultController resultMenu;

    [Header("Battle Rewards")]
    public int goldRewards;
    public int expRewards;

    public GameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.Start;
        StartCoroutine(SetupBattle());
    }

    void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            // If not, set the instance to this
            Instance = this;
        }
        else
        {
            // If instance already exists, destroy this GameObject
            Destroy(gameObject);
            return;
        }
    }

    IEnumerator SetupBattle()
    {
        DisableBattleButton();
        goldRewards = 0;
        expRewards = 0;

        GameObject player = Instantiate(playerPrefab, playerPosition);
        player.GetComponent<UnitController>();

        GameObject enemy = Instantiate(enemyPrefab, enemyPosition);
        enemy.GetComponent<UnitController>();

        playerHUD.SetHUD(playerUnit);
        Debug.Log(playerUnit.GetHP());
        enemyHUD.SetHUD(enemyUnit);
        Debug.Log(enemyUnit.GetHP());

        yield return new WaitForSeconds(2f);

        Debug.Log("Battle has been set up.");

        currentState = GameState.PlayerTurn;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        DisableBattleButton();

        bool isDead = enemyUnit.TakeDamage(playerUnit.GetDamage());

        enemyHUD.SetHP(enemyUnit.GetHP());
        enemyParticle.SetActive(true);

        Debug.Log("Attack succesfully");

        yield return new WaitForSeconds(2f);

        enemyParticle.SetActive(false);

        if (isDead)
        {
            currentState = GameState.Won;
            EndBattle();
        }
        else
        {
            currentState = GameState.EnemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerDefend()
    {
        DisableBattleButton();

        playerUnit.Defend(true);

        Debug.Log("Player try to defend.");

        yield return new WaitForSeconds(2f);

        currentState = GameState.EnemyTurn;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        playerParticle.SetActive(true);

        Debug.Log("Enemy attack!");

        yield return new WaitForSeconds(1f);

        playerParticle.SetActive(false);

        if (!playerUnit.IsDefend())
        {
            bool isDead = playerUnit.TakeDamage(enemyUnit.GetDamage());

            playerHUD.SetHP(playerUnit.GetHP());

            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                currentState = GameState.Lost;
                EndBattle();
            }
            else
            {
                currentState = GameState.PlayerTurn;
                PlayerTurn();
            }
        }
        else
        {
            playerUnit.Defend(false);
            Debug.Log("No damage taken from enemy.");

            yield return new WaitForSeconds(1f);

            currentState = GameState.PlayerTurn;
            PlayerTurn();
        }   
    }

    void EndBattle()
    {
        if(currentState == GameState.Won)
        {
            BattleRewards();
            Debug.Log("You have won the battle.");
        }
        else if(currentState == GameState.Lost)
        {
            Debug.Log("You have lost the battle.");
        }
        resultMenu.ShowResultMenu(this);
    }

    void PlayerTurn()
    {
        EnableBattleButton();
        Debug.Log("Your turn.");
    }

    public void OnAttackButton()
    {
        if (currentState != GameState.PlayerTurn)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnDefendButton()
    {
        if (currentState != GameState.PlayerTurn)
            return;

        StartCoroutine(PlayerDefend());
    }

    public void OnSkillButton()
    {
        if (currentState != GameState.PlayerTurn)
            return;

        skillController.ShowSkillsMenu();
    }

    void EnableBattleButton()
    {
        attackButton.interactable = true;
        defendButton.interactable = true;
        skillButton.interactable = true;
    }

    void DisableBattleButton()
    {
        attackButton.interactable = false;
        defendButton.interactable = false;
        skillButton.interactable = false;
    }

    void BattleRewards()
    {
        goldRewards = 5 * enemyUnit.unit.level;
        expRewards = 20 * enemyUnit.unit.level;
    }
}
