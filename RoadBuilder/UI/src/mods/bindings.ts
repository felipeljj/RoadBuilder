import { bindValue, trigger } from "cs2/api";
import { NetSectionItem } from "domain/NetSectionItem";
import { RoadBuilderToolModeEnum } from "domain/RoadBuilderToolMode";
import mod from "mod.json";

export const allNetSections$ = bindValue<NetSectionItem[]>("RoadBuilder", "NetSections");
export const roadBuilderToolMode$ = bindValue(mod.id, "RoadBuilderToolMode", RoadBuilderToolModeEnum.None);

export const editPrefab = trigger.bind(null, mod.id, "ActionPopup.Edit");
export const createFromTemplate = trigger.bind(null, mod.id, "ActionPopup.New");
export const cancelPickerAction = trigger.bind(null, mod.id, "ActionPopup.Cancel");
export const toggleTool = trigger.bind(null, mod.id, "ToggleTool");